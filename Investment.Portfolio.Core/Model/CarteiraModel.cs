namespace Investment.Portfolio.Core.Model
{
    public class CarteiraModel
    {
        public string Ativo { get; set; }
        public string TipoProduto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoMedio { get; set; }
        public decimal PrecoAtual { get; set; }
        public decimal LucroPerda { get; set; }
        public decimal Posicao { get; set; }
    }
}
