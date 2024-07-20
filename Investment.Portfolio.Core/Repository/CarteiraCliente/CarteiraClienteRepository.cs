using Investment.Portfolio.Core.Factory.Interface;
using Investment.Portfolio.Core.Factory;
using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Repository.CarteiraCliente.Interface;
using Dapper;
using Investment.Portfolio.Core.Dto;

namespace Investment.Portfolio.Core.Repository.CarteiraCliente
{
    public class CarteiraClienteRepository : ICarteiraClienteRepository
    {
        private readonly string QueryListarCarteira = "";
        private readonly string QueryAtualizarCarteira = "";
        private readonly IConnectionFactory _factory;
        public CarteiraClienteRepository(IConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<CarteiraModel>>ListarCarteiraCliente(long cpfCnpj)
        {
            try
            {
                using (var conn = _factory.CreateConnection(DataBaseConnection.INVEST_PORTF))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = QueryListarCarteira;
                        var result = await conn.QueryAsync<CarteiraDto>(cmd.CommandText);
                        return result.Select(x => x.toModel());
                    }
                }
            }
            catch (Exception)
            {
                return Enumerable.Empty<CarteiraModel>();
            }
        }
    }
}
