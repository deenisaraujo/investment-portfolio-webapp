using Investment.Portfolio.Core.Model;

namespace Investment.Portfolio.Core.Command.CarteiraCliente.Interface
{
    public interface IListarCarteiraClienteCommand
    {
        Task<IEnumerable<CarteiraModel>> Executar(long cpfCnpj, int idProduto);
    }
}
