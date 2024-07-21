using System.Net;

namespace Investment.Portfolio.Core.Model
{
    public class StatusModel
    {
        public HttpStatusCode Status { get; set; }
        public string Mensagem { get; set; }
    }
}
