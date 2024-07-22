using Investment.Portfolio.Core.Command.GestaoProdutos.Interface;
using Investment.Portfolio.Core.Request;
using Microsoft.AspNetCore.Mvc;

namespace Investment.Portfolio.WebApp.Controllers
{
    public class GestaoProdutosController : Controller
    {
        public readonly IDeletarProdutoCommand _deletarProdutoCommand;
        public readonly IEnviarEmailCommand _enviarEmailCommand;
        public readonly IInserirAlterarProdutoCommand _inserirAlterarProdutoCommand;
        public readonly IListarProdutosCommand _listarProdutosCommand;
        private readonly IConfiguration _configuration;
        public GestaoProdutosController(
         IDeletarProdutoCommand deletarProdutoCommand,
         IEnviarEmailCommand enviarEmailCommand,
         IInserirAlterarProdutoCommand inserirAlterarProdutoCommand,
         IListarProdutosCommand listarProdutosCommand,
         IConfiguration config)
        {
            _deletarProdutoCommand = deletarProdutoCommand;
            _enviarEmailCommand = enviarEmailCommand;
            _inserirAlterarProdutoCommand = inserirAlterarProdutoCommand;
            _listarProdutosCommand = listarProdutosCommand;
            _configuration = config;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CadastrarEditarProduto()
        {
            return View();
        }

        /// <summary>
        /// Método responsável por deletar os produtos do portfólio.
        /// </summary>
        public async Task<IActionResult> DeletarProduto(int codProduto)
        {
            _deletarProdutoCommand.Executar(codProduto);
            return Ok();
        }

        /// <summary>
        /// Método responsável por enviar email aos administradores sobre o vencimento próximo dos produtos.
        /// </summary>
        public async Task<IActionResult> EnvioEmail(long cpfCnpj)
        {
            var conta = _configuration.GetSection("DadosEmail").Get<EmailRequest>();
            return Ok(await _enviarEmailCommand.Executar(conta));
        }

        /// <summary>
        /// Método responsável por inserir e alterar os produtos do portfólio.
        /// </summary>
        public async Task<IActionResult> InserirAlterarProduto([FromBody]ProdutoRequest request)
        {
            return Ok(await _inserirAlterarProdutoCommand.Executar(request));
        }

        /// <summary>
        /// Método responsável por listar os produtos do portfólio.
        /// </summary>
        public async Task<IActionResult> ListarProdutos(int idProduto, string produto)
        {
            return Ok(await _listarProdutosCommand.Executar(idProduto, produto));
        } 
    }
}
