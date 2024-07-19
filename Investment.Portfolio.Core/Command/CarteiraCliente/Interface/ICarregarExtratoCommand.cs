using Investment.Portfolio.Core.Model;
namespace Investment.Portfolio.Core.Command.CarteiraCliente.Interface
{
    public interface ICarregarExtratoCommand
    {
        Task<IEnumerable<ExtratoModel>> Executar(DateTime dataExtrato);
    }
}
