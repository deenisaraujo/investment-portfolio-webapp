namespace Investment.Portfolio.Core.Request
{
    public class OrdemRequest
    {
        public long CpfCnpj { get; set; }
        public string Ativo { get; set; }
        public string Negociacao { get; set; }
        public char TipoOperacao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal ValorOperacao => Preco * Quantidade;
    }
}
