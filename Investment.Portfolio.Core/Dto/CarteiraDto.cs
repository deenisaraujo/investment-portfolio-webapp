using Investment.Portfolio.Core.Model;

namespace Investment.Portfolio.Core.Dto
{
    public class CarteiraDto
    {
        public string DS_ATIVO { get; set; }
        public string DS_TIPO_PRODUTO { get; set; }
        public int NR_QUANTIDADE { get; set; }
        public decimal VL_PRECO_ATUAL { get; set; }
        public decimal VL_LUCRO_PERDA { get; set; }
        public decimal VL_POSICAO { get; set; }

        public CarteiraModel toModel() =>
            new()
            {
                Ativo = DS_ATIVO,
                TipoProduto = DS_TIPO_PRODUTO,
                Quantidade = NR_QUANTIDADE,
                PrecoMedio = VL_POSICAO/NR_QUANTIDADE,
                PrecoAtual = VL_PRECO_ATUAL,
                LucroPerda = VL_LUCRO_PERDA,
                Posicao = VL_POSICAO
            };
    }
}
