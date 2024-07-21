using Investment.Portfolio.Core.Command.GestaoProdutos.Interface;
using Investment.Portfolio.Core.Facade.Email.Interface;
using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Request;

namespace Investment.Portfolio.Core.Command.GestaoProdutos
{
    public class EnviarEmailCommand : IEnviarEmailCommand
    {
        public readonly IEnviarEmailFacade _enviarEmailFacade;
        public EnviarEmailCommand(IEnviarEmailFacade enviarEmailFacade)
        {
            _enviarEmailFacade = enviarEmailFacade;
        }
        public Task<StatusModel> Executar(EmailRequest request) => _enviarEmailFacade.EnviarEmailVencimento(request);
    }
}
