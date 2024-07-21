using Investment.Portfolio.Core.Command.GestaoProdutos.Interface;
using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Repository.GestaoProdutos.Interface;

namespace Investment.Portfolio.Core.Command.GestaoProdutos
{
    public class ListarProdutosCommand : IListarProdutosCommand
    {
        public readonly IGestaoProdutosRepository _gestaoProdutosRepository;
        public ListarProdutosCommand(IGestaoProdutosRepository gestaoProdutosRepository)
        {
            _gestaoProdutosRepository = gestaoProdutosRepository;
        }
        public Task<IEnumerable<ProdutosModel>> Executar(int idProduto, string produto) => _gestaoProdutosRepository.ListarProduto(idProduto, produto);
    }
}
