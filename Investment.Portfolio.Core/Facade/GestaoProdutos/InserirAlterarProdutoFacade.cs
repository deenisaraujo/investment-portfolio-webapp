using Investment.Portfolio.Core.Facade.GestaoProdutos.Interface;
using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Repository.GestaoProdutos.Interface;
using Investment.Portfolio.Core.Request;

namespace Investment.Portfolio.Core.Facade.GestaoProdutos
{
    public class InserirAlterarProdutoFacade : IInserirAlterarProdutorFacade
    {
        public readonly IGestaoProdutosRepository _gestaoProdutosRepository;
        public InserirAlterarProdutoFacade(IGestaoProdutosRepository gestaoProdutosRepository)
        {
            _gestaoProdutosRepository = gestaoProdutosRepository;
        }
        public Task<StatusModel> InserirAlterarProduto(ProdutoRequest request)
        {
            if (request.IdProduto == 0)
                return _gestaoProdutosRepository.InserirProduto(request);
            else
                return _gestaoProdutosRepository.AlterarProduto(request);
        }
    }
}
