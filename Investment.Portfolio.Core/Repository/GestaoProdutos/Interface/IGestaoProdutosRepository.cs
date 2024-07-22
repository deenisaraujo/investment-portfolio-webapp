using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Request;

namespace Investment.Portfolio.Core.Repository.GestaoProdutos.Interface
{
    public interface IGestaoProdutosRepository
    {
        Task<StatusModel> AlterarProduto(ProdutoRequest request);
        void DeletarProduto(int codProduto);
        Task<StatusModel> InserirProduto(ProdutoRequest request);
        Task<IEnumerable<ProdutosModel>> ListarProduto(int idProduto, string produto);
        Task<IEnumerable<ProdutosModel>> ListarProdutoProximoVencimento(int DiasParaVencer);
        bool VerificaExisteProduto(string produto);
    }
}
