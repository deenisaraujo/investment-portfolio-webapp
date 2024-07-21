using Investment.Portfolio.Core.Enum;

namespace Investment.Portfolio.Core.Request
{
    public class OrdemRequest
    {
        public int IdProduto { get; set; }
        public long CpfCnpj { get; set; }
        public string Ativo { get; set; }
        public string TipoProduto { get; set; }
        public string EspecificacaoTitulo { get; set; }
        public string Negociacao { get; set; }
        public TipoOperacaoEnum TipoOperacao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public decimal ValorOperacao => Preco * Quantidade;
    }
}
