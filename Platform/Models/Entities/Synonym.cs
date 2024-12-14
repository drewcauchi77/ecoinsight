using Platform.Models.Entities.Linkings;

namespace Platform.Models.Entities
{
    public class Synonym
    {
        // Primary key
        public int Id { get; set; }

        // The synonym name
        public string Value { get; set; } = string.Empty;
        
        // Many to many relationship with ingredients
        public List<IngredientSynonym> IngredientSynonyms { get; } = [];
    }
}
