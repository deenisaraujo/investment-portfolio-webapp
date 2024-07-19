using Investment.Portfolio.Core.Command.CarteiraCliente.Interface;
using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Repository.CarteiraCliente.Interface;

namespace Investment.Portfolio.Core.Command.CarteiraCliente
{
    public class ListarCarteiraClienteCommand : IListarCarteiraClienteCommand
    {
        public readonly ICarteiraClienteRepository _carteiraClienteRepository;
        public ListarCarteiraClienteCommand(ICarteiraClienteRepository carteiraClienteRepository)
        {
            _carteiraClienteRepository = carteiraClienteRepository;
        }
        public Task<IEnumerable<CarteiraModel>> Executar(long cpfCnpj) => _carteiraClienteRepository.ListarCarteiraCliente(cpfCnpj);
    }
}
