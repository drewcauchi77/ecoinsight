using Platform.Models.Entities;

namespace Platform.Models.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> AllRecipes();
        Task CreateRecipe(Recipe recipe);
    }
}
