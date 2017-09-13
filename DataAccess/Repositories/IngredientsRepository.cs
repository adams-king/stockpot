using Stockpot.DataAccess.Entities;

namespace Stockpot.DataAccess.Repositories
{
    public class IngredientsRepository : RepositoryBase<Ingredient, int>
    {
        public IngredientsRepository(DbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
