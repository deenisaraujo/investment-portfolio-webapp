using Investment.Portfolio.Core.Model;

namespace Investment.Portfolio.Core.Command.GestaoProdutos.Interface
{
    public interface IListarProdutosCommand
    {
        Task<IEnumerable<ProdutosModel>> Executar(int idProduto, string produto);
    }
}
