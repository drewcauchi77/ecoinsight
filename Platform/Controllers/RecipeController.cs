using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Platform.Models.Entities;
using Platform.Models.Repositories.Interfaces;

namespace Platform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(IRecipeRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        // Get: api/recipe
        [HttpGet]
        public async Task<IActionResult> Get_AllRecipes()
        {
            var allRecipes = await _recipeRepository.AllRecipes();
            return Ok(allRecipes);
        }

        // Post: api/recipe
        [HttpPost]
        public async Task<IActionResult> Post_CreateRecipe([FromBody] Recipe recipe)
        {
            if (recipe == null)
            {
                return BadRequest("Recipe is null");
            }
            
            await _recipeRepository.CreateRecipe(recipe);
            return CreatedAtAction(nameof(Get_AllRecipes), new { id = recipe.Id }, recipe);
        }
    }
}
