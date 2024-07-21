using Investment.Portfolio.Core.Enum;
using Investment.Portfolio.Core.Facade.OperacoesCompraVenda.Interface;
using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Repository.GestaoProdutos.Interface;
using Investment.Portfolio.Core.Repository.OperacoesCompraVenda.Interface;
using Investment.Portfolio.Core.Request;
using System.Net;

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
        /// <summary>
        /// Método responsável por identificar e executar o tipo de operação (Compra, Venda) 
        /// e atualizar a quantidade dispoível do produto.
        /// </summary>
        public Task<StatusModel> OperacoesCompraVenda(OrdemRequest request)
        {
            bool executado = false;

            //Consulta o produto
            var produto = _gestaoProdutosRepository.ListarProduto(request.IdProduto, null).Result.First();
            
            //Verifica se há disponibilidade do produto
            if (produto.QuantidadeDisponivel > 0)
                switch (request.TipoOperacao)
                {
                    //Atualiza a quantidade disponível do produto para compra ou venda
                    case TipoOperacaoEnum.Compra:
                         executado = _gestaoProdutosRepository.AlterarProduto(new ProdutoRequest() { IdProduto = request.IdProduto, Quantidade = produto.QuantidadeDisponivel - request.Quantidade, EhOrdem = true }).IsCompletedSuccessfully;
                        break;
                    case TipoOperacaoEnum.Venda:
                        executado = _gestaoProdutosRepository.AlterarProduto(new ProdutoRequest() { IdProduto = request.IdProduto, Quantidade = produto.QuantidadeDisponivel + request.Quantidade, EhOrdem = true }).IsCompletedSuccessfully;
                        break;
                    default:
                        return Task.FromResult(new StatusModel() { Status = HttpStatusCode.OK, Mensagem = "Não existe ordem de compra ou venda!" });
                }

            //Registra a compra ou venda do produto no banco de dados
            if (executado)
                return _operacoesCompraVendaRepository.OrdemCompraVendaProduto(request);
            else
                return Task.FromResult(new StatusModel() { Status = HttpStatusCode.BadRequest, Mensagem = "Erro ao tentar efetuar compra ou venda de produto!" });
        }
    }
}
