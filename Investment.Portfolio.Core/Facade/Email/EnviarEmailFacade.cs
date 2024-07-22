using Investment.Portfolio.Core.Facade.Email.Interface;
using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Repository.GestaoProdutos.Interface;
using Investment.Portfolio.Core.Request;
using Investment.Portfolio.Core.Service.Interface;
using System.Net;

namespace Investment.Portfolio.Core.Facade.Email
{
    public class EnviarEmailFacade : IEnviarEmailFacade
    {
        private readonly IEnviarEmailService _enviarEmailService;
        private readonly IGestaoProdutosRepository _gestaoProdutosRepository;
        public EnviarEmailFacade(IEnviarEmailService enviarEmailService, IGestaoProdutosRepository gestaoProdutosRepository)
        {
            _enviarEmailService = enviarEmailService;
            _gestaoProdutosRepository = gestaoProdutosRepository;
        }
        public Task<StatusModel> EnviarEmailVencimento(EmailRequest request)
        {
            bool enviou = false;

            //Lista os produtos que estão próximos do vencimento
            var proximoVencimento = _gestaoProdutosRepository.ListarProdutoProximoVencimento(request.DiasParaVencer).Result.ToList();
            if(proximoVencimento.Count().Equals(0))return Task.FromResult(new StatusModel() { Status = HttpStatusCode.OK, Mensagem = $"Não há nenhum produto para vencer nos próximos {request.DiasParaVencer} dias!" });
            for (int i = 0; i < proximoVencimento.Count; i++)
            {
                //Atribui o diretório do template do email a váriavel
                string diretorio = string.Format("TemplateEmail/VencimentoProuto.html", AppDomain.CurrentDomain.FriendlyName);

                //Lê todo o texto do arquivo do template
                if (!string.IsNullOrEmpty(diretorio))
                {
                    request.Html = File.ReadAllText(diretorio);
                }

                //Substitui as palavras dinâmicas do email pelas fornecidas no request
                request.Html = request.Html.Replace("{$PRODUTO}", proximoVencimento[i].Ativo);
                request.Html = request.Html.Replace("{$VENCIMENTO}", proximoVencimento[i].DataVencimentoFormatada);
                request.EmailDestinatario = proximoVencimento[i].EmailAdministrador;

                //Dispara o email
                enviou = _enviarEmailService.Enviar(request);
            }
            //Retorna a mensagem de sucesso ou erro do disparo do email
            if (enviou)
                return Task.FromResult(new StatusModel() { Status = HttpStatusCode.OK, Mensagem = "Email enviado com sucesso!" });
            else
                return Task.FromResult(new StatusModel() { Status = HttpStatusCode.BadRequest, Mensagem = "Erro ao tentar enviar email!" });
        }
    }
}
