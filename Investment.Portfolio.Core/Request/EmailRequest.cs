namespace Investment.Portfolio.Core.Request
{
    public class EmailRequest
    {
        public string EmailRemetente {  get; set; }
        public string EmailDestinatario { get; set; }
        public string Assunto { get; set; }
        public string Html { get; set; }
        public string Senha { get; set; }
        public string Host { get; set; }
        public int Porta { get; set; }
        public int DiasParaVencer { get; set; }
    }
}
