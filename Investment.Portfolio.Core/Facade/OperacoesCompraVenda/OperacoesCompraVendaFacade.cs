using Investment.Portfolio.Core.Facade.OperacoesCompraVenda.Interface;
using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Repository.CarteiraCliente.Interface;
using Investment.Portfolio.Core.Repository.OperacoesCompraVenda.Interface;
using Investment.Portfolio.Core.Request;

namespace Investment.Portfolio.Core.Facade.OperacoesCompraVenda
{
    public class OperacoesCompraVendaFacade : IOperacoesCompraVendaFacade
    {
        public readonly IOperacoesCompraVendaRepository _operacoesCompraVendaRepository;
        public readonly ICarteiraClienteRepository _carteiraClienteRepository;
        public OperacoesCompraVendaFacade(IOperacoesCompraVendaRepository operacoesCompraVendaRepository, ICarteiraClienteRepository carteiraClienteRepository)
        {
            _operacoesCompraVendaRepository = operacoesCompraVendaRepository;
            _carteiraClienteRepository = carteiraClienteRepository;
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
                //Atualiza carteira do cliente após efetuar uma venda ou compra de ativo
                return _carteiraClienteRepository.AtualizarCarteira(request);
            else
                return Task.FromResult(new StatusModel() {Status = 0, Mensagem = "Erro ao tentar efetuar " + request.TipoOperacao });
        }
    }
}
