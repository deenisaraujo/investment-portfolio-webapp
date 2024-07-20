namespace Investment.Portfolio.Core.Request
{
    public class ProdutoRequest
    {
        public int IdProduto { get; set; }
        public string Ativo { get; set; }
        public string TipoProduto { get; set; }
        public string EspecificacaoTitulo { get; set; }
        public string Negociacao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
    }
}
