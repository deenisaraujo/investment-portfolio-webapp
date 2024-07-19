using Investment.Portfolio.Core.Command.OperacoesCompraVenda.Interface;
using Investment.Portfolio.Core.Facade.GestaoProdutos;
using Investment.Portfolio.Core.Facade.OperacoesCompraVenda;
using Investment.Portfolio.Core.Facade.OperacoesCompraVenda.Interface;
using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Request;

namespace Investment.Portfolio.Core.Command.OperacoesCompraVenda
{
    public class OperacaoCompraVendaCommand : IOperacaoCompraVendaCommand
    {
        public readonly IOperacoesCompraVendaFacade _operacoesCompraVendaFacade;
        public OperacaoCompraVendaCommand(IOperacoesCompraVendaFacade operacoesCompraVendaFacade)
        {
            _operacoesCompraVendaFacade = operacoesCompraVendaFacade;
        }
        public Task<StatusModel> Executar(OrdemRequest request) => _operacoesCompraVendaFacade.OperacoesCompraVenda(request);
    }
}
