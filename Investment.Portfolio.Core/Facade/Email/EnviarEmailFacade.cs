using Investment.Portfolio.Core.Facade.Email.Interface;
using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Request;
using Investment.Portfolio.Core.Service.Interface;
using System.Net;

namespace Investment.Portfolio.Core.Facade.Email
{
    public class EnviarEmailFacade : IEnviarEmailFacade
    {
        private readonly IEnviarEmailService _enviarEmailService;
        public EnviarEmailFacade(IEnviarEmailService enviarEmailService) 
        { 
            _enviarEmailService = enviarEmailService;
        }
        public Task<StatusModel> EnviarEmailVencimento(EmailRequest request)
        {
            //Atribui o diretório do template do email a váriavel
            string diretorio = string.Format("TemplateEmail/VencimentoProuto.html", AppDomain.CurrentDomain.FriendlyName);

            //Lê todo o texto do arquivo do template
            if (!string.IsNullOrEmpty(diretorio))
            {
                request.Html = File.ReadAllText(diretorio);
            }

            //Substitui as palavras dinâmicas do email pelas fornecidas no request
            request.Html = request.Html.Replace("{$PRODUTO}", request.Produto);
            request.Html = request.Html.Replace("{$VENCIMENTO}", request.Vencimento.ToString("dd/MM/yyyy"));

            //Dispara o email
            var enviou = _enviarEmailService.Enviar(request);

            //Retorna a mensagem de sucesso ou erro do disparo do email
            if(enviou)
                return Task.FromResult(new StatusModel() { Status = HttpStatusCode.OK, Mensagem = "Email enviado com sucesso!" });
            else
                return Task.FromResult(new StatusModel() { Status = HttpStatusCode.BadRequest, Mensagem = "Erro ao tentar enviar email!" });
        }
    }
}
