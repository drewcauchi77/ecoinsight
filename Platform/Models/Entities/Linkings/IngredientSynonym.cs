namespace Platform.Models.Entities.Linkings
{
    public class IngredientSynonym
    {
        // Foreign ID for the ingredient
        public int IngredientId { get; set; }

        // Foreign ID for the synonym
        public int SynonymId { get; set; }

        public Ingredient Ingredient { get; set; } = null!;
        public Synonym Synonym { get; set; } = null!;
    }
}
