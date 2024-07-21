using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Request;

namespace Investment.Portfolio.Core.Facade.Email.Interface
{
    public interface IEnviarEmailFacade
    {
        Task<StatusModel> EnviarEmailVencimento(EmailRequest request);
    }
}
