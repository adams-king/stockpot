using Stockpot.DataAccess;

namespace Stockpot.WebApi
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public ConnectionStringProvider(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }
    }
}
