using Investment.Portfolio.Core.Facade.GestaoProdutos.Interface;
using Investment.Portfolio.Core.Model;
using Investment.Portfolio.Core.Repository.GestaoProdutos.Interface;
using Investment.Portfolio.Core.Request;
using System.Net;

namespace Investment.Portfolio.Core.Facade.GestaoProdutos
{
    public class InserirAlterarProdutoFacade : IInserirAlterarProdutorFacade
    {
        public readonly IGestaoProdutosRepository _gestaoProdutosRepository;
        public InserirAlterarProdutoFacade(IGestaoProdutosRepository gestaoProdutosRepository)
        {
            _gestaoProdutosRepository = gestaoProdutosRepository;
        }
        /// <summary>
        /// Método responsável por verificar se o produto já existe e efetuar a
        /// inserção ou alteração
        /// </summary>
        public Task<StatusModel> InserirAlterarProduto(ProdutoRequest request)
        {
            //Verifica se já existe o produto para não cadastrar produto repetido
            if (!_gestaoProdutosRepository.VerificaExisteProduto(request.Ativo))
            {
                if (request.IdProduto == 0)
                    //Insere o produto no banco
                    return _gestaoProdutosRepository.InserirProduto(request);
                else
                    //Atualiza o produto no banco
                    return _gestaoProdutosRepository.AlterarProduto(request);
            }
            else
            {
                return Task.FromResult(new StatusModel() { Status = HttpStatusCode.OK, Mensagem = "Já existe esse produto!" });
            }
        }
    }
}
