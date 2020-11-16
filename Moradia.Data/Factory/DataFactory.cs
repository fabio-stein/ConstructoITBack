using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Moradia.Data
{
    public class DataFactory
    {
        private readonly SqlConnectionFactory _factory;

        public DataFactory(SqlConnectionFactory factory)
        {
            _factory = factory;
        }

        public DbConnection OpenConnection()
        {
            return _factory.CreateConnection(_factory.BaseConnectionString);
        }
    }
}
