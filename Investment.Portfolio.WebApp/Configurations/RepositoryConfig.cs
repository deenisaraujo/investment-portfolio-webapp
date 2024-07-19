using Investment.Portfolio.Core.Repository.CarteiraCliente.Interface;
using Investment.Portfolio.Core.Repository.CarteiraCliente;
using Investment.Portfolio.Core.Repository.GestaoProdutos.Interface;
using Investment.Portfolio.Core.Repository.GestaoProdutos;
using Investment.Portfolio.Core.Repository.OperacoesCompraVenda.Interface;
using Investment.Portfolio.Core.Repository.OperacoesCompraVenda;

namespace Investment.Portfolio.WebApp.Configurations
{
    public static class RepositoryConfig
    {
        public static void ConfigRepository(this IServiceCollection services)
        {
            //Carteira do Cliente
            services.AddScoped<ICarteiraClienteRepository, CarteiraClienteRepository>();

            //Gestão de Produtos
            services.AddScoped<IGestaoProdutosRepository, GestaoProdutosRepository>();

            //Operacoes de Compra e Venda
            services.AddScoped<IOperacoesCompraVendaRepository, OperacoesCompraVendaRepository>();
        }
    }
}
