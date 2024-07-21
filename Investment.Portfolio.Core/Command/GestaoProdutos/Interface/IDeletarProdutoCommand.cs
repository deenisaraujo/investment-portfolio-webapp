using Investment.Portfolio.Core.Model;

namespace Investment.Portfolio.Core.Command.GestaoProdutos.Interface
{
    public interface IDeletarProdutoCommand
    {
        Task<StatusModel> Executar(int codProduto);
    }
}
