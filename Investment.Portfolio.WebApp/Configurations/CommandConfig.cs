using Investment.Portfolio.Core.Command.CarteiraCliente;
using Investment.Portfolio.Core.Command.CarteiraCliente.Interface;
using Investment.Portfolio.Core.Command.GestaoProdutos;
using Investment.Portfolio.Core.Command.GestaoProdutos.Interface;
using Investment.Portfolio.Core.Command.OperacoesCompraVenda;
using Investment.Portfolio.Core.Command.OperacoesCompraVenda.Interface;

namespace Investment.Portfolio.WebApp.Configurations
{
    public static class CommandConfig
    {
        public static void ConfigCommand(this IServiceCollection services)
        {
            //Carteira do Cliente
            services.AddScoped<ICarregarExtratoCommand, CarregarExtratoCommand>();
            services.AddScoped<IListarCarteiraClienteCommand, ListarCarteiraClienteCommand>();
            
            //Gestão de Produtos
            services.AddScoped<IDeletarProdutoCommand, DeletarProdutoCommand>();
            services.AddScoped<IEnviarEmailCommand, EnviarEmailCommand>();
            services.AddScoped<IInserirAlterarProdutoCommand, InserirAlterarProdutoCommand>();
            services.AddScoped<IListarProdutosCommand, ListarProdutosCommand>();

            //Operacoes de Compra e Venda
            services.AddScoped<IOperacaoCompraVendaCommand, OperacaoCompraVendaCommand>();
        }
    }
}
