using Investment.Portfolio.Core.Factory.Interface;
using Investment.Portfolio.Core.Factory;
using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Repository.OperacoesCompraVenda.Interface;
using Dapper;
using Investment.Portfolio.Core.Dto;
using Investment.Portfolio.Core.Request;

namespace Investment.Portfolio.Core.Repository.OperacoesCompraVenda
{
    public class OperacoesCompraVendaRepository : IOperacoesCompraVendaRepository
    {
        private readonly string QueryCompra = "";
        private readonly string QueryVenda = "";
        private readonly IConnectionFactory _factory;
        public OperacoesCompraVendaRepository(IConnectionFactory factory)
        {
            _factory = factory;
        }

        public bool OrdemCompraProduto(OrdemRequest request)
        {
            try
            {
                using (var conn = _factory.CreateConnection(DataBaseConnection.INVEST_PORTF))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = QueryCompra;
                        conn.ExecuteAsync(cmd.CommandText);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool OrdemVendaProduto(OrdemRequest request)
        {
            try
            {
                using (var conn = _factory.CreateConnection(DataBaseConnection.INVEST_PORTF))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = QueryVenda;
                        conn.ExecuteAsync(cmd.CommandText);
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ExtratoModel>>CarregarExtrato(DateTime dataExtrato)
        {
            try
            {
                using (var conn = _factory.CreateConnection(DataBaseConnection.INVEST_PORTF))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = QueryVenda;
                        var result = await conn.QueryAsync<ExtratoDto>(cmd.CommandText);
                        return result.Select(x => x.toModel());
                    }
                }
            }
            catch (Exception)
            {
                 return Enumerable.Empty<ExtratoModel>();
            }
        }
    }
}
