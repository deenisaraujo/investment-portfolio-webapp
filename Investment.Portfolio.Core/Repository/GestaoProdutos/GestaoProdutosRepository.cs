using Dapper;
using Investment.Portfolio.Core.Dto;
using Investment.Portfolio.Core.Factory;
using Investment.Portfolio.Core.Factory.Interface;
using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Repository.GestaoProdutos.Interface;
using Investment.Portfolio.Core.Request;

namespace Investment.Portfolio.Core.Repository.GestaoProdutos
{
    public class GestaoProdutosRepository : IGestaoProdutosRepository
    {
        private readonly string QueryAtualizarProduto = "";
        private readonly string QueryDeletarProduto = "";
        private readonly string QueryInserirProduto = "INSERT INTO invest_portf.TB_PRODUTO(DS_ATIVO,DS_TIPO_PRODUTO,DS_ESPECIFICACAO_TITULO,DS_NEGOCIACAO,NR_QUANTIDADE_DISPONIVEL,VL_PRECO,DT_ALTERACAO)";
        private readonly string QueryListarProduto = "";
        private readonly string QueryVerificaProdutoExiste = "SELECT * FROM invest_portf.TB_PRODUTO";
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
                        cmd.CommandText = QueryAtualizarProduto;
                        await conn.ExecuteAsync(cmd.CommandText);
                    }
                }
                return await Task.FromResult(new StatusModel() { Status = 1 });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new StatusModel() { Status = 0, Mensagem = "Erro ao tentar alterar o produto: " + ex });
            }
        }
        public async Task<StatusModel> DeletarProduto(long cpfCnpj, int codProduto)
        {
            try
            {
                using (var conn = _factory.CreateConnection(DataBaseConnection.INVEST_PORTF))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = QueryDeletarProduto;
                        await conn.ExecuteAsync(cmd.CommandText);
                    }
                }
                return await Task.FromResult(new StatusModel() { Status = 1 });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new StatusModel() { Status = 0, Mensagem = "Erro ao tentar deletar o produto: " + ex });
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
                        
                        cmd.CommandText = QueryInserirProduto + $"VALUES('{request.Ativo}','{request.TipoProduto}','{request.EspecificacaoTitulo}','{request.Negociacao}',{request.Quantidade},{request.Preco.ToString().Replace(",",".")},sysdate)";
                        await conn.ExecuteAsync(cmd.CommandText);
                    }
                }
                return await Task.FromResult(new StatusModel() { Status = 1 });
            }
            catch (Exception ex)
            {
                return await Task.FromResult(new StatusModel() { Status = 0, Mensagem = "Erro ao tentar inserir o produto: " + ex });
            }
        }
        public async Task<IEnumerable<ProdutosModel>> ListarProduto(string produto)
        {
            try
            {
                using (var conn = _factory.CreateConnection(DataBaseConnection.INVEST_PORTF))
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandText = QueryListarProduto;
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
                        var result = conn.Query<int>(cmd.CommandText).First();
                        return result >= 0 ? true : false;
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
