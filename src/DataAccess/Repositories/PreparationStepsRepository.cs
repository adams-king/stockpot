using Microsoft.EntityFrameworkCore;
using Stockpot.DataAccess.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Stockpot.DataAccess.Repositories
{
    public class PreparationStepsRepository : RepositoryBase<PreparationStep, int>
    {
        public PreparationStepsRepository(DbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<byte> GetMaxOrder(int recipeId)
        {
            return await DbContext.PreparationSteps
                .Where(ps => ps.RecipeId == recipeId)
                .MaxAsync(ps => ps.Order);
        }
    }
}
