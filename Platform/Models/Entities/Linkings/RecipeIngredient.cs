namespace Platform.Models.Entities.Linkings
{
    public class RecipeIngredient
    {
        // Foreign ID for the recipe
        public int RecipeId { get; set; }

        // Foreign ID for the ingredient
        public int IngredientId { get; set; }

        public Recipe Recipe { get; set; } = null!;
        public Ingredient Ingredient { get; set; } = null!;
    }
}
