using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Request;

namespace Investment.Portfolio.Core.Command.OperacoesCompraVenda.Interface
{
    public interface IOperacaoCompraVendaCommand
    {
        Task<StatusModel> Executar(OrdemRequest request);
    }
}
