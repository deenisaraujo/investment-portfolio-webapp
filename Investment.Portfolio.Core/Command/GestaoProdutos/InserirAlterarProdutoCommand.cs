using Investment.Portfolio.Core.Command.GestaoProdutos.Interface;
using Investment.Portfolio.Core.Facade.GestaoProdutos.Interface;
using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Request;

namespace Investment.Portfolio.Core.Command.GestaoProdutos
{
    public class InserirAlterarProdutoCommand : IInserirAlterarProdutoCommand
    {
        public readonly IInserirAlterarProdutorFacade _inserirAlterarProdutoFacade;
        public InserirAlterarProdutoCommand(IInserirAlterarProdutorFacade inserirAlterarProdutoFacade)
        {
            _inserirAlterarProdutoFacade = inserirAlterarProdutoFacade;
        }
        public Task<StatusModel> Executar(ProdutoRequest request) => _inserirAlterarProdutoFacade.InserirAlterarProduto(request);
    }
}
