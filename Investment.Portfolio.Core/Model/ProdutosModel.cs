namespace Investment.Portfolio.Core.Model
{
    public class ProdutosModel
    {
        public int IdProduto { get; set; }
        public string Ativo { get; set; }
        public string TipoProduto { get; set; }
        public string EspecificacaoTitulo { get; set; }
        public string Negociacao {  get; set; }
        public int QuantidadeDisponivel { get; set; }
        public decimal Preco { get; set; }
        public string EmailAdministrador { get; set; }
        public string DataAlteracao { get; set; }
        public string DataVencimento { get; set; }
        public string DataVencimentoFormatada { get; set; }
    }
}
