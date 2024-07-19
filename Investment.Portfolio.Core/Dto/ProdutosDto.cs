using Investment.Portfolio.Core.Model;
using System.Security.Cryptography;

namespace Investment.Portfolio.Core.Dto
{
    public class ProdutosDto
    {
        public string DS_ATIVO { get; set; }
        public string DS_ESPECIFICACAO_TITULO { get; set; }
        public string DS_NEGOCIACAO { get; set; }
        public int NR_QUANTIDADE { get; set; }
        public decimal VL_PRECO { get; set; }

        public ProdutosModel toModel() =>
        new()
            {
                Ativo = DS_ATIVO,
                EspecificacaoTitulo =DS_ESPECIFICACAO_TITULO,
                Negociacao = DS_NEGOCIACAO,
                Quantidade = NR_QUANTIDADE,
                Preco = VL_PRECO
            };
    }
}
