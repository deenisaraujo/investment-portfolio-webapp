using Investment.Portfolio.Core.Command.GestaoProdutos.Interface;
using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Repository.GestaoProdutos.Interface;

namespace Investment.Portfolio.Core.Command.GestaoProdutos
{
    public class DeletarProdutoCommand : IDeletarProdutoCommand
    {
        public readonly IGestaoProdutosRepository _gestaoProdutosRepository;
        public DeletarProdutoCommand(IGestaoProdutosRepository gestaoProdutosRepository)
        {
            _gestaoProdutosRepository = gestaoProdutosRepository;
        }
        public Task<StatusModel> Executar(long cpfCnpj, int codProduto) => _gestaoProdutosRepository.DeletarProduto(cpfCnpj, codProduto);
    }
}
