namespace Platform.Models.Entities.Linkings
{
    public class RecipeMealType
    {
        // Foreign ID for the recipe
        public int RecipeId { get; set; }

        // Foreign ID for the meal type
        public int MealTypeId { get; set; }

        public Recipe Recipe { get; set; } = null!;
        public MealType MealType { get; set; } = null!;
    }
}
