using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Request;

namespace Investment.Portfolio.Core.Command.GestaoProdutos.Interface
{
    public interface IInserirAlterarProdutoCommand
    {
        Task<StatusModel> Executar(ProdutoRequest request);
    }
}
