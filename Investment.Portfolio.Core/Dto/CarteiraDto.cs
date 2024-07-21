using Investment.Portfolio.Core.Model;

namespace Investment.Portfolio.Core.Dto
{
    public class CarteiraDto
    {
        public string DS_ATIVO { get; set; }
        public string DS_TIPO_PRODUTO { get; set; }
        public int NR_QUANTIDADE { get; set; }
        public decimal VL_PRECO { get; set; }
        public decimal VL_POSICAO { get; set; }

        public CarteiraModel toModel() =>
            new()
            {
                Ativo = DS_ATIVO,
                TipoProduto = DS_TIPO_PRODUTO,
                Quantidade = NR_QUANTIDADE,
                Preco = VL_PRECO,
                Posicao = VL_POSICAO
            };
    }
}
