using Investment.Portfolio.Core.Model;

namespace Investment.Portfolio.Core.Repository.CarteiraCliente.Interface
{
    public interface ICarteiraClienteRepository
    {
        Task<IEnumerable<CarteiraModel>> ListarCarteiraCliente(long cpfCnpj, int idProduto);
    }
}
