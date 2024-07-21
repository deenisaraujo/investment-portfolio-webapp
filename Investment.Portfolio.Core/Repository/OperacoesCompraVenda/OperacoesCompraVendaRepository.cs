using Investment.Portfolio.Core.Factory.Interface;
using Investment.Portfolio.Core.Factory;
using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Repository.OperacoesCompraVenda.Interface;
using Dapper;
using Investment.Portfolio.Core.Dto;
using System.Net;
using Investment.Portfolio.Core.Request;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Investment.Portfolio.Core.Repository.OperacoesCompraVenda
{
    public class OperacoesCompraVendaRepository : IOperacoesCompraVendaRepository
    {
        private readonly string QueryCompraVenda = "INSERT INTO invest_portf.TB_ORDEM(ID_PRODUTO,NR_CPF_CNPJ,DS_ATIVO,DS_TIPO_PRODUTO,DS_NEGOCIACAO,DS_TIPO_OPERACAO,DS_ESPECIFICACAO_TITULO,NR_QUANTIDADE,VL_PRECO,VL_OPERACAO,DT_OPERACAO)";
        private readonly string QueryExtrato = "SELECT * FROM invest_portf.TB_ORDEM";
        private readonly IConnectionFactory _factory;
        public OperacoesCompraVendaRepository(IConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<StatusModel> OrdemCompraVendaProduto(ProdutosModel produto, OrdemRequest ordem)
        {
            try
            {
                using (var conn = _factory.CreateConnection(DataBaseConnection.INVEST_PORTF))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = QueryCompraVenda + $" VALUES({produto.IdProduto},{ordem.CpfCnpj},'{produto.Ativo}', '{produto.TipoProduto}', '{produto.Negociacao}', '{ordem.TipoOperacao}', '{produto.EspecificacaoTitulo}', {ordem.Quantidade}, {produto.Preco.ToString().Replace(",", ".")}, {(produto.Preco * ordem.Quantidade).ToString().Replace(",", ".")}, '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}')";
                        await conn.ExecuteAsync(cmd.CommandText);
                    }
                }
                return await Task.FromResult(new StatusModel() { Status = HttpStatusCode.OK, Mensagem = $"{ordem.TipoOperacao.ToString()} efetuada com sucesso!" });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new StatusModel() { Status = HttpStatusCode.BadRequest, Mensagem = $"Erro ao tentar {ordem.TipoOperacao.ToString()} produto: " + ex.Message });
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
                        if (!dataExtrato.Equals(null) && dataExtrato.ToString() != "01/01/0001 00:00:00")
                            cmd.CommandText = QueryExtrato + $" WHERE DT_OPERACAO = '{dataExtrato.ToString("yyyy-MM-dd")}'";
                        else
                            cmd.CommandText = QueryExtrato ;
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
