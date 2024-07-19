using Investment.Portfolio.Core.Command.OperacoesCompraVenda.Interface;
using Investment.Portfolio.Core.Request;
using Microsoft.AspNetCore.Mvc;

namespace Investment.Portfolio.WebApp.Controllers
{
    public class OperacoesCompraVendaController : Controller
    {
        public readonly IOperacaoCompraVendaCommand _operacaoCompraCommand;
        public OperacoesCompraVendaController(
         IOperacaoCompraVendaCommand operacaoCompraCommand)
        {
            _operacaoCompraCommand = operacaoCompraCommand;
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Método responsável por efetuar compra e venda de produto e atualizar carteira do cliente.
        /// </summary>
        public async Task<IActionResult> CompraProduto(OrdemRequest request)
        {
            return Ok(await _operacaoCompraCommand.Executar(request));
        }
    }
}
