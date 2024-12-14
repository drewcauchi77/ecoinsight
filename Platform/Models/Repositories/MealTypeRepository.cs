using Microsoft.EntityFrameworkCore;
using Platform.Models.Contexts;
using Platform.Models.Entities;
using Platform.Models.Repositories.Interfaces;

namespace Platform.Models.Repositories
{
    public class MealTypeRepository: IMealTypeRepository
    {
        private readonly DatabaseContext _dbContext;

        public MealTypeRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MealType>> AllMealTypes()
        {
            return await _dbContext.MealType.ToListAsync();
        }
    }
}
