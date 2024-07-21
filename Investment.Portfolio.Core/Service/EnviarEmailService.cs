using Investment.Portfolio.Core.Service.Interface;
using System.Net.Mail;
using System.Net;
using System.Text;
using Investment.Portfolio.Core.Request;

namespace Investment.Portfolio.Core.Service
{
    public class EnviarEmailService : IEnviarEmailService
    {
        public bool Enviar(EmailRequest request)
        {
            try
            {
                MailMessage email = new MailMessage();
                //Email do remetente
                email.From = new MailAddress(request.EmailRemetente);
                //Email do destinatario
                email.To.Add(request.EmailDestinatario);
                //prioridade do email
                email.Priority = MailPriority.High;
                //Informa se o conteudo do email será em html ou texto
                email.IsBodyHtml = true;
                //Assunto do email
                email.Subject = request.Assunto;
                //Corpo do email
                email.Body = request.Html;
                //Codificação do assunto do email para que os caracteres acentuados sejam reconhecidos.
                email.SubjectEncoding = Encoding.GetEncoding("ISO-8859-1");
                //Codificação do corpo do email para que os caracteres acentuados sejam reconhecidos.
                email.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                //Objeto responsável pelo envio do email
                SmtpClient smtp = new SmtpClient();
                //Endereço do servidor SMTP
                smtp.Host = request.Host;
                //Porta do servidor SMTP
                smtp.Port = request.Porta;
                //Credenciais o email do remetente
                smtp.Credentials = new NetworkCredential(request.EmailRemetente, request.Senha);
                //Ativa a criptografia STARTTLS
                smtp.EnableSsl = true;
                //Envia o email
                smtp.Send(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
