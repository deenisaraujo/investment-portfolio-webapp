using Investment.Portfolio.Core.Request;

namespace Investment.Portfolio.Core.Service.Interface
{
    public interface IEnviarEmailService
    {
        bool Enviar(EmailRequest request);
    }
}
