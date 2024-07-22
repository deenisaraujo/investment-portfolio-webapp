using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Request;

namespace Investment.Portfolio.Core.Repository.OperacoesCompraVenda.Interface
{
    public interface IOperacoesCompraVendaRepository
    {
        Task<StatusModel> OrdemCompraVendaProduto(ProdutosModel produto, OrdemRequest ordem);
        Task<IEnumerable<ExtratoModel>> CarregarExtrato(long cpfCnpj, DateTime dataExtrato);
    }
}
