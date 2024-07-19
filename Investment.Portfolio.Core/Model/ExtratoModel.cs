namespace Investment.Portfolio.Core.Model
{
    public class ExtratoModel
    {
        public int Nota { get; set; }
        public DateTime DataOperacao { get; set; }
        public long CpfCnpj { get; set; }
        public string Ativo { get; set; }
        public string Negociacao { get; set; }
        public char TipoOperacao { get; set; }
        public string EspecificacaoTitulo { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal ValorOperacao { get; set; }
    }
}
