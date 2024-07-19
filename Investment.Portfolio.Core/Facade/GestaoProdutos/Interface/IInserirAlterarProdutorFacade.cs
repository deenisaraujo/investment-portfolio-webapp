using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Request;

namespace Investment.Portfolio.Core.Facade.GestaoProdutos.Interface
{
    public interface IInserirAlterarProdutorFacade
    {
        Task<StatusModel> InserirAlterarProduto(ProdutoRequest request);
    }
}
