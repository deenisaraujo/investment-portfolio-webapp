using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Request;

namespace Investment.Portfolio.Core.Repository.OperacoesCompraVenda.Interface
{
    public interface IOperacoesCompraVendaRepository
    {
        Task<StatusModel> OrdemCompraVendaProduto(OrdemRequest request);
        Task<IEnumerable<ExtratoModel>> CarregarExtrato(DateTime dataExtrato);
    }
}
