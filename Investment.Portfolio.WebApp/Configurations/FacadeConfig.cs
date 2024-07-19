﻿using Investment.Portfolio.Core.Facade.GestaoProdutos;
using Investment.Portfolio.Core.Facade.GestaoProdutos.Interface;
using Investment.Portfolio.Core.Facade.OperacoesCompraVenda.Interface;
using Investment.Portfolio.Core.Facade.OperacoesCompraVenda;

namespace Investment.Portfolio.WebApp.Configurations
{
    public static class FacadeConfig
    {
        public static void ConfigFacade(this IServiceCollection services)
        {
            //Gestão de Produtos
            services.AddScoped<IInserirAlterarProdutorFacade, InserirAlterarProdutoFacade>();

            //Operacoes de Compra e Venda
            services.AddScoped<IOperacoesCompraVendaFacade, OperacoesCompraVendaFacade>();
        }
    }
}
