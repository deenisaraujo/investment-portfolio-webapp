using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Request;

namespace Investment.Portfolio.Core.Repository.OperacoesCompraVenda.Interface
{
    public interface IOperacoesCompraVendaRepository
    {
        bool OrdemCompraProduto(OrdemRequest request);
        bool OrdemVendaProduto(OrdemRequest request);
        Task<IEnumerable<ExtratoModel>> CarregarExtrato(DateTime dataExtrato);
    }
}
