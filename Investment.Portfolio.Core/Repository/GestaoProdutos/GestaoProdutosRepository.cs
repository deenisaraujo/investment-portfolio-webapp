using Dapper;
using Investment.Portfolio.Core.Dto;
using Investment.Portfolio.Core.Factory;
using Investment.Portfolio.Core.Factory.Interface;
using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Repository.GestaoProdutos.Interface;
using Investment.Portfolio.Core.Request;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net;

namespace Investment.Portfolio.Core.Repository.GestaoProdutos
{
    public class GestaoProdutosRepository : IGestaoProdutosRepository
    {
        private readonly string QueryAtualizarProduto = "UPDATE invest_portf.TB_PRODUTO";
        private readonly string QueryDeletarProduto = "DELETE FROM invest_portf.TB_PRODUTO";
        private readonly string QueryInserirProduto = "INSERT INTO invest_portf.TB_PRODUTO(DS_ATIVO,DS_TIPO_PRODUTO,DS_ESPECIFICACAO_TITULO,DS_NEGOCIACAO,NR_QUANTIDADE_DISPONIVEL,VL_PRECO,DS_EMAIL_ADMINISTRADOR,DT_ALTERACAO,DT_VENCIMENTO)";
        private readonly string QueryListarProduto = "SELECT * FROM invest_portf.TB_PRODUTO";
        private readonly string QueryVerificaProdutoExiste = "SELECT count(*) FROM invest_portf.TB_PRODUTO";
        private readonly string QueryProximoVencimento = "SELECT DS_ATIVO,DS_EMAIL_ADMINISTRADOR,DT_VENCIMENTO FROM invest_portf.TB_PRODUTO";
        private readonly IConnectionFactory _factory;
        public GestaoProdutosRepository(IConnectionFactory factory)
        {
            _factory = factory;
        }

        public async Task<StatusModel> AlterarProduto(ProdutoRequest request)
        {
            try
            {
                using (var conn = _factory.CreateConnection(DataBaseConnection.INVEST_PORTF))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        if (request.EhOrdem)
                        {
                            cmd.CommandText = QueryAtualizarProduto + $"  SET NR_QUANTIDADE_DISPONIVEL = {request.Quantidade} WHERE ID_PRODUTO = {request.IdProduto}";
                        }
                        else
                        {
                            cmd.CommandText = QueryAtualizarProduto + $" SET DS_ATIVO = '{request.Ativo}', DS_TIPO_PRODUTO = " +
                             $"'{request.TipoProduto}', DS_ESPECIFICACAO_TITULO = " +
                             $"'{request.EspecificacaoTitulo}', DS_NEGOCIACAO = " +
                             $"'{request.Negociacao}', NR_QUANTIDADE_DISPONIVEL = " +
                             $"{request.Quantidade}, VL_PRECO = " +
                             $"{request.Preco}, DS_EMAIL_ADMINISTRADOR = " +
                             $"'{request.EmailAdministrador}', DT_VENCIMENTO = " +
                             $"'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', DT_ALTERACAO = " +
                             $"'{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}'" +
                             $" WHERE ID_PRODUTO = {request.IdProduto}";
                        }
                        await conn.ExecuteAsync(cmd.CommandText);
                    }
                }
                return await Task.FromResult(new StatusModel() { Status = HttpStatusCode.OK, Mensagem = "Alteração efetuada com sucesso!" });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new StatusModel() { Status = HttpStatusCode.BadRequest, Mensagem = "Erro ao tentar alterar o produto: " + ex.Message });
            }
        }
        public async Task<StatusModel> DeletarProduto(int codProduto)
        {
            try
            {
                using (var conn = _factory.CreateConnection(DataBaseConnection.INVEST_PORTF))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = QueryDeletarProduto + $" WHERE ID_PRODUTO = {codProduto}";
                        await conn.ExecuteAsync(cmd.CommandText);
                    }
                }
                return await Task.FromResult(new StatusModel() { Status = HttpStatusCode.OK, Mensagem = "Exclusão efetuada com sucesso!" });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new StatusModel() { Status = HttpStatusCode.BadRequest, Mensagem = "Erro ao tentar excluir o produto: " + ex.Message });
            }
        }
        public async Task<StatusModel> InserirProduto(ProdutoRequest request)
        {
            try
            {
                using (var conn = _factory.CreateConnection(DataBaseConnection.INVEST_PORTF))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        request.DataVencimento = DateTime.Parse("28/07/2024");
                        cmd.CommandText = QueryInserirProduto + $"VALUES('{request.Ativo}','{request.TipoProduto}','{request.EspecificacaoTitulo}','{request.Negociacao}',{request.Quantidade},{request.Preco.ToString().Replace(",", ".")},'{request.EmailAdministrador}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}','{request.DataVencimento.ToString("yyyy-MM-dd HH:mm:ss")}')";
                        await conn.ExecuteAsync(cmd.CommandText);
                    }
                }
                return await Task.FromResult(new StatusModel() { Status = HttpStatusCode.OK, Mensagem = "Inserido com sucesso!" });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new StatusModel() { Status = HttpStatusCode.BadRequest, Mensagem = "Erro ao tentar inserir o produto: " + ex.Message });
            }
        }
        public async Task<IEnumerable<ProdutosModel>> ListarProduto(int idProduto, string produto)
        {
            try
            {
                using (var conn = _factory.CreateConnection(DataBaseConnection.INVEST_PORTF))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        var strSQL = new List<string>(); 
                        if (idProduto > 0) strSQL.Add($"ID_PRODUTO = {idProduto}");
                        if (!string.IsNullOrEmpty(produto)) strSQL.Add($"DS_ATIVO = '{produto}'");

                        cmd.CommandText = string.Concat(QueryListarProduto, strSQL.Count > 0 ? " WHERE " : string.Empty, string.Join(" OR ", strSQL));
                        var result = await conn.QueryAsync<ProdutosDto>(cmd.CommandText);
                        return result.Select(x => x.toModel());
                    }
                }
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<ProdutosModel>();
            }
        }
        public async Task<IEnumerable<ProdutosModel>> ListarProdutoProximoVencimento(int DiasParaVencer)
        {
            try
            {
                using (var conn = _factory.CreateConnection(DataBaseConnection.INVEST_PORTF))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = QueryProximoVencimento + $" WHERE DT_VENCIMENTO BETWEEN '{DateTime.Now.ToString("yyyy-MM-dd")}' AND '{DateTime.Now.AddDays(DiasParaVencer).ToString("yyyy-MM-dd")}'";
                        var result = await conn.QueryAsync<ProdutosDto>(cmd.CommandText);
                        return result.Select(x => x.toModel());
                    }
                }
            }
            catch (Exception)
            {
                return Enumerable.Empty<ProdutosModel>();
            }
        }
        public bool VerificaExisteProduto(string produto)
        {
            try
            {
                using (var conn = _factory.CreateConnection(DataBaseConnection.INVEST_PORTF))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = QueryVerificaProdutoExiste + $" WHERE DS_ATIVO = '{produto}'";
                        var result = conn.Query<int?>(cmd.CommandText).First();
                        return result == 1 ? true : false;
                    }
                }
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
