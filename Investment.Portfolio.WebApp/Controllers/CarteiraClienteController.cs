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
        public async Task<IActionResult> ListarCarteira(long cpfCnpj, int idProduto)
        {
            var list = await _listarCarteiraClienteCommand.Executar(cpfCnpj, idProduto);
            return Ok(list.Where(x => x.Quantidade > 0).ToList());
        }

        /// <summary>
        /// Método responsável por listar a carteira do cliente.
        /// </summary>
        public async Task<IActionResult>CarregarExtrato(long cpfCnpj, DateTime dataExtrato)
        {
            return Ok(await _carregarExtratoCommand.Executar(cpfCnpj, dataExtrato));
        }
    }
}
