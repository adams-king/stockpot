using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Stockpot.DataAccess
{
    public class DbContextProvider
    {
        private readonly StockpotDbContext _dbContext;

        public DbContextProvider(IConnectionStringProvider connectionStringProvider, ILoggerFactory loggerFactory)
        {
            var connectionString = connectionStringProvider.ConnectionString;

            var optionsBuilder = new DbContextOptionsBuilder<StockpotDbContext>();

            optionsBuilder.UseMySql(connectionString);
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            _dbContext = new StockpotDbContext(optionsBuilder.Options);
        }

        internal StockpotDbContext DbContext => _dbContext;

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
