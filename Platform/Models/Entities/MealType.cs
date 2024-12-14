using Platform.Models.Entities.Linkings;

namespace Platform.Models.Entities
{
    public class MealType
    {
        // Primary key
        public int Id { get; set; }

        // Name of the meal type
        public string Name { get; set; } = string.Empty;

        // Many to many relationship with recipe
        public List<RecipeMealType> RecipeMealTypes { get; } = [];
    }
}
