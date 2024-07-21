using Investment.Portfolio.Core.Model;

namespace Investment.Portfolio.Core.Dto
{
    public class ExtratoDto
    {
        public int NR_NOTA { get; set; }
        public DateTime DT_OPERACAO { get; set; }
        public long NR_CPF_CNPJ { get; set; }
        public string DS_ATIVO { get; set; }
        public string DS_TIPO_PRODUTO { get; set; }
        public string DS_NEGOCIACAO { get; set; }
        public char DS_TIPO_OPERACAO { get; set; }
        public string DS_ESPECIFICACAO_TITULO { get; set; }
        public int NR_QUANTIDADE { get; set; }
        public decimal VL_PRECO { get; set; }
        public decimal VL_OPERACAO { get; set; }
        public DateTime DT_ALTERACAO { get; set; }

        public ExtratoModel toModel() =>
             new()
             {
                 Nota = NR_NOTA,
                 DataOperacao = DT_OPERACAO,
                 CpfCnpj = NR_CPF_CNPJ,
                 Ativo = DS_ATIVO,
                 TipoProduto = DS_TIPO_PRODUTO,
                 Negociacao = DS_NEGOCIACAO,
                 TipoOperacao = DS_TIPO_OPERACAO,
                 EspecificacaoTitulo = DS_ESPECIFICACAO_TITULO,
                 Quantidade = NR_QUANTIDADE,
                 Preco = VL_PRECO,
                 ValorOperacao = VL_OPERACAO,
                 DataAlteracao = DT_ALTERACAO
             };
    }
}
