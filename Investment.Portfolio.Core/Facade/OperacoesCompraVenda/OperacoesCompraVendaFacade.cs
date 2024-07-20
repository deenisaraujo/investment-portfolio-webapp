using Investment.Portfolio.Core.Facade.OperacoesCompraVenda.Interface;
using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Repository.CarteiraCliente.Interface;
using Investment.Portfolio.Core.Repository.GestaoProdutos;
using Investment.Portfolio.Core.Repository.GestaoProdutos.Interface;
using Investment.Portfolio.Core.Repository.OperacoesCompraVenda.Interface;
using Investment.Portfolio.Core.Request;

namespace Investment.Portfolio.Core.Facade.OperacoesCompraVenda
{
    public class OperacoesCompraVendaFacade : IOperacoesCompraVendaFacade
    {
        public readonly IOperacoesCompraVendaRepository _operacoesCompraVendaRepository;
        public readonly IGestaoProdutosRepository _gestaoProdutosRepository;
        public OperacoesCompraVendaFacade(IOperacoesCompraVendaRepository operacoesCompraVendaRepository, IGestaoProdutosRepository gestaoProdutosRepository)
        {
            _operacoesCompraVendaRepository = operacoesCompraVendaRepository;
            _gestaoProdutosRepository = gestaoProdutosRepository;
        }
        public Task<StatusModel> OperacoesCompraVenda(OrdemRequest request)
        {
            bool executado;
            switch (request.TipoOperacao)
            {
                case 'C':
                    executado = _operacoesCompraVendaRepository.OrdemCompraProduto(request);
                    break;
                case 'V':
                    executado = _operacoesCompraVendaRepository.OrdemVendaProduto(request);
                    break;
                default:
                    return Task.FromResult(new StatusModel() { Status = 0, Mensagem = "Não existe ordem de compra ou venda!"});
            }
            if (executado)
                //Atualiza a quantidade disponivel do produto após efetuar uma venda ou compra de produto
                return _gestaoProdutosRepository.AlterarProduto(new ProdutoRequest());
            else
                return Task.FromResult(new StatusModel() {Status = 0, Mensagem = "Erro ao tentar efetuar " + request.TipoOperacao });
        }
    }
}
