using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Request;

namespace Investment.Portfolio.Core.Command.GestaoProdutos.Interface
{
    public interface IEnviarEmailCommand
    {
        Task<StatusModel> Executar(EmailRequest request);
    }
}
