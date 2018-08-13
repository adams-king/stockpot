using Microsoft.EntityFrameworkCore;
using Stockpot.DataAccess.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Stockpot.DataAccess.Repositories
{
    public class IngredientsRepository : RepositoryBase<Ingredient, int>
    {
        public IngredientsRepository(DbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Ingredient> GetByName(string name)
        {
            var ingredient = await GetDbSet()
                .Where(i => i.Name == name)
                .SingleOrDefaultAsync();

            return ingredient;
        }
    }
}
