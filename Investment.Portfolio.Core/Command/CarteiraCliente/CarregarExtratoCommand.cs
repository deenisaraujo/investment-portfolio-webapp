using Investment.Portfolio.Core.Command.CarteiraCliente.Interface;
using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Repository.OperacoesCompraVenda.Interface;

namespace Investment.Portfolio.Core.Command.CarteiraCliente
{
    public class CarregarExtratoCommand : ICarregarExtratoCommand
    {
        public readonly IOperacoesCompraVendaRepository _operacoesCompraVendaRepository;
        public CarregarExtratoCommand(IOperacoesCompraVendaRepository operacoesCompraVendaRepository)
        {
            _operacoesCompraVendaRepository = operacoesCompraVendaRepository;
        }
        public Task<IEnumerable<ExtratoModel>> Executar(DateTime dataExtrato) => _operacoesCompraVendaRepository.CarregarExtrato(dataExtrato);
    }
}
