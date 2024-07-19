using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Request;

namespace Investment.Portfolio.Core.Facade.OperacoesCompraVenda.Interface
{
    public interface IOperacoesCompraVendaFacade
    {
        Task<StatusModel> OperacoesCompraVenda(OrdemRequest request);
    }
}
