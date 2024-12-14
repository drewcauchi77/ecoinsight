using Platform.Models.Entities;

namespace Platform.Models.Repositories.Interfaces
{
    public interface IMealTypeRepository
    {
        Task<IEnumerable<MealType>> AllMealTypes();
    }
}
