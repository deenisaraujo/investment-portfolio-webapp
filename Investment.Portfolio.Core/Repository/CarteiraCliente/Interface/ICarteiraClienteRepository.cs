using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Request;

namespace Investment.Portfolio.Core.Repository.CarteiraCliente.Interface
{
    public interface ICarteiraClienteRepository
    {
        Task<IEnumerable<CarteiraModel>> ListarCarteiraCliente(long cpfCnpj);
        Task<StatusModel> AtualizarCarteira(OrdemRequest request);
    }
}
