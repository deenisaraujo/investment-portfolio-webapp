using System.Data;

namespace Investment.Portfolio.Core.Factory.Interface
{
    public interface IConnectionFactory
    {
       IDbConnection CreateConnection(DataBaseConnection pConnectionName);
    }
}
