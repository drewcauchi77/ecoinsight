using Microsoft.EntityFrameworkCore;
using Platform.Models.Contexts;
using Platform.Models.Entities;
using Platform.Models.Repositories.Interfaces;

namespace Platform.Models.Repositories
{
    public class RecipeRepository: IRecipeRepository
    {
        private readonly DatabaseContext _dbContext;

        public RecipeRepository(DatabaseContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Recipe>> AllRecipes()
        {
            return await _dbContext.Recipe.ToListAsync();
        }

        public async Task CreateRecipe(Recipe recipe)
        {
            await _dbContext.Recipe.AddAsync(recipe);
            await _dbContext.SaveChangesAsync();
        }
    }
}
