using Investment.Portfolio.Core.Enum;

namespace Investment.Portfolio.Core.Request
{
    public class OrdemRequest
    {
        public int IdProduto { get; set; }
        public long CpfCnpj { get; set; }
        public TipoOperacaoEnum TipoOperacao { get; set; }
        public int Quantidade { get; set; }
    }
}
