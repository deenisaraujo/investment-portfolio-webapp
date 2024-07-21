using Investment.Portfolio.Core.Factory.Interface;
using Investment.Portfolio.Core.Factory;
using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Repository.OperacoesCompraVenda.Interface;
using Dapper;
using Investment.Portfolio.Core.Dto;
using Investment.Portfolio.Core.Request;
using System.Net;

namespace Investment.Portfolio.Core.Repository.OperacoesCompraVenda
{
    public class OperacoesCompraVendaRepository : IOperacoesCompraVendaRepository
    {
        private readonly string QueryCompra = "";
        private readonly string QueryVenda = "";
        private readonly string QueryExtrato = "";
        private readonly IConnectionFactory _factory;
        public OperacoesCompraVendaRepository(IConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<StatusModel> OrdemCompraVendaProduto(OrdemRequest request)
        {
            try
            {
                using (var conn = _factory.CreateConnection(DataBaseConnection.INVEST_PORTF))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = QueryCompra;
                        await conn.ExecuteAsync(cmd.CommandText);
                    }
                }
                return await Task.FromResult(new StatusModel() { Status = HttpStatusCode.OK, Mensagem = $"{request.TipoOperacao.ToString()} efetuada com sucesso!" });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new StatusModel() { Status = HttpStatusCode.BadRequest, Mensagem = $"Erro ao tentar {request.TipoOperacao.ToString()} produto: " + ex.Message });
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
                        cmd.CommandText = QueryExtrato;
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
