using Investment.Portfolio.Core.Factory.Interface;
using MySql.Data.MySqlClient;
using System.Data;

namespace Investment.Portfolio.Core.Factory
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly Dictionary<DataBaseConnection, string> _currentDatabaseSettings;
        public ConnectionFactory(Dictionary<DataBaseConnection, string> currentDatabaseSettings)
        {
            _currentDatabaseSettings = currentDatabaseSettings;
        }
        public IDbConnection CreateConnection(DataBaseConnection pConnectionName)
        {
            string connectionString;
            if (_currentDatabaseSettings.TryGetValue(pConnectionName, out connectionString))
            {
                switch (pConnectionName)
                {
                    case DataBaseConnection.INVEST_PORTF:
                        return new MySqlConnection(connectionString);
                }
            }
            return null;
        }
    }
}
