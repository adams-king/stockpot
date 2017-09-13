using Stockpot.DataAccess.Entities;

namespace Stockpot.DataAccess.Repositories
{
    public class TagsRepository : RepositoryBase<Tag, int>
    {
        public TagsRepository(DbContextProvider dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
