using Investment.Portfolio.Core.Command.GestaoProdutos.Interface;
using Investment.Portfolio.Core.Request;
using Microsoft.AspNetCore.Mvc;

namespace Investment.Portfolio.WebApp.Controllers
{
    public class GestaoProdutosController : Controller
    {
        public readonly IDeletarProdutoCommand _deletarProdutoCommand;
        public readonly IEnvioEmailCommand _envioEmailCommand;
        public readonly IInserirAlterarProdutoCommand _inserirAlterarProdutoCommand;
        public readonly IListarProdutosCommand _listarProdutosCommand;
        public GestaoProdutosController(
         IDeletarProdutoCommand deletarProdutoCommand,
         IEnvioEmailCommand envioEmailCommand,
         IInserirAlterarProdutoCommand inserirAlterarProdutoCommand,
         IListarProdutosCommand listarProdutosCommand)
        {
            _deletarProdutoCommand = deletarProdutoCommand;
            _envioEmailCommand = envioEmailCommand;
            _inserirAlterarProdutoCommand = inserirAlterarProdutoCommand;
            _listarProdutosCommand = listarProdutosCommand;
        }
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Método responsável por deletar os produtos do portfólio.
        /// </summary>
        public async Task<IActionResult> DeletarProduto(long cpfCnpj, int codProduto)
        {
            return Ok(await _deletarProdutoCommand.Executar(cpfCnpj, codProduto));
        }

        /// <summary>
        /// Método responsável por enviar email aos administradores sobre o vencimento próximo dos produtos.
        /// </summary>
        public async Task<IActionResult> EnvioEmail()
        {
            return Ok();
        }

        /// <summary>
        /// Método responsável por inserir e alterar os produtos do portfólio.
        /// </summary>
        public async Task<IActionResult> InserirAlterarProduto(ProdutoRequest request)
        {
            return Ok(await _inserirAlterarProdutoCommand.Executar(request));
        }

        /// <summary>
        /// Método responsável por listar os produtos do portfólio.
        /// </summary>
        public async Task<IActionResult> ListarProdutos(string produto)
        {
            return Ok(await _listarProdutosCommand.Executar(produto));
        } 
    }
}
