using Investment.Portfolio.Core.Model;

namespace Investment.Portfolio.Core.Dto
{
    public class ProdutosDto
    {
        public int ID_PRODUTO { get; set; }
        public string DS_ATIVO { get; set; }
        public string DS_TIPO_PRODUTO { get; set; }
        public string DS_ESPECIFICACAO_TITULO { get; set; }
        public string DS_NEGOCIACAO { get; set; }
        public int NR_QUANTIDADE_DISPONIVEL { get; set; }
        public decimal VL_PRECO { get; set; }
        public string DS_EMAIL_ADMINISTRADOR { get; set; }
        public DateTime DT_ALTERACAO { get; set; }
        public DateTime DT_VENCIMENTO { get; set; }

        public ProdutosModel toModel() =>
        new()
        {
            IdProduto = ID_PRODUTO,
            Ativo = DS_ATIVO,
            TipoProduto = DS_TIPO_PRODUTO,
            EspecificacaoTitulo = DS_ESPECIFICACAO_TITULO,
            Negociacao = DS_NEGOCIACAO,
            QuantidadeDisponivel = NR_QUANTIDADE_DISPONIVEL,
            Preco = VL_PRECO,
            EmailAdministrador = DS_EMAIL_ADMINISTRADOR,
            DataAlteracao = DT_ALTERACAO,
            DataVencimento = DT_VENCIMENTO
        };
    }
}
