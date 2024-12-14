using Platform.Models.Entities.Linkings;

namespace Platform.Models.Entities
{
    public class Ingredient
    {
        // Primary key
        public int Id { get; set; }

        // Name of the ingredient
        public string Name { get; set; } = string.Empty;

        // Many to many relationship with recipes
        public List<RecipeIngredient> RecipeIngredients { get; } = [];

        // Many to many relationship with synonyms
        public List<IngredientSynonym> IngredientSynonyms { get; } = [];
    }
}
