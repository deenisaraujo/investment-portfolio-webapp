using Investment.Portfolio.Core.Command.CarteiraCliente.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Investment.Portfolio.WebApp.Controllers
{
    public class CarteiraClienteController : Controller
    {
        public readonly IListarCarteiraClienteCommand _listarCarteiraClienteCommand;
        public readonly ICarregarExtratoCommand _carregarExtratoCommand;
        public CarteiraClienteController(
            IListarCarteiraClienteCommand listarCarteiraClienteCommand,
            ICarregarExtratoCommand carregarExtratoCommand)
        {
            _listarCarteiraClienteCommand = listarCarteiraClienteCommand;
            _carregarExtratoCommand = carregarExtratoCommand;
        }
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Método responsável por listar a carteira do cliente.
        /// </summary>
        public async Task<IActionResult> ListarCarteira(long cpfCnpj)
        {
            return Ok(await _listarCarteiraClienteCommand.Executar(cpfCnpj));
        }

        /// <summary>
        /// Método responsável por listar a carteira do cliente.
        /// </summary>
        public async Task<IActionResult>CarregarExtrato(DateTime dataExtrato)
        {
            return Ok(await _carregarExtratoCommand.Executar(dataExtrato));
        }
    }
}
