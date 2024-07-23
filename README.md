SISTEMA DE GESTÃO DE PORTFÓLIO DE INVESTIMENTOS



Resumo:
-  O projeto foi desenvolvido em .Net Core 8 na linguagem C# utilizando banco de dados MySQL.


Passos para executar projeto:

- Para rodar o projeto basta clonar a aplicação no git através do link “” ou abrir a pasta do projeto que foi enviado através do “” no Visual Studio e em seguida verificar se o projeto para rodar encontra – se no “IIS Express” conforme imagem abaixo:




Caso contrário basta clicar com botão direito do mouse em cima do projeto “Investment.Portfolio.WebApp” e selecionar a opção “Set as Startup Project” que irá aparecer a opção. Feito isso basta clica no mesmo para rodar o projeto.


Obs: vale destacar 3 pontos que foram criados para efetuar os testes com o fluxo completo:

- Foi criado um frontend básico para possibilitar efetuar os cadastros e poder visualizar de forma mais ágil e prática;

- Para inserir os dados foi criado um banco de dados e hospedado na nuvem, e toda a configuração já está feita, então basta rodar a aplicação que já será possível visualizar e cadastrar os dados;

- Para efetuar o disparo de e-mail, foi criado um e-mail de teste chamado “contato_invest@hotmail.com” para fazer a autenticação do remetente, e o mesmo também já se encontra configurado, então basta rodar a aplicação e cadastrar um e-mail válido no campo e-mail do administrador na tela de cadastro de produtos para conseguir visualizar o e-mail.



Passos para utilizar a aplicação:

- Ao rodar o projeto a tela inicial abaixo, caso a formatação da página esteja sem estilo de página ou formatação, limpe o cache ou tente executar em aba anônima.




- O primeiro passo é cadastrar um produto clicando em  ;







- Em seguida preencha o formulário com todos os campos.

-----------EXEMPLO DE PREENCHIMENTO-----------------

. Produto: LCI XP (Nome Fantasia);

. Tipo Produto: LETRA DE CRÉDITO IMOBLIÁRIO (Tipo do produto por extenso));

. Especificação do produto: LETRA DE CRÉDITO IMOBLIÁRIO XP INC (Nome do produto sem abreviação);

Negociação: ex: Bovespa, BM&F, RENDA FIXA...;

Quantidade: 20;

Preço: 1000,00 (Não colocar ponto no milhar);
 
Email Administrador: e-mail da pessoa que for receber o e-mail para testar;

Data Vencimento: está definido para enviar o e-mail para o vencimento dos próximos 5 dias, mas pode ser mudado através do appsettings;


- Após salvar, voltar e atualizar a página é possível visualizar os dados no grid conforme a imagem abaixo:




- Na última coluna é possível efetuar a exclusão clicando no ícone de lixeira e é possível editar no ícone ao lado que será aberto a página conforme a imagem abaixo bastando apenas alterar qualquer campo exceto o nome do produto;




- Ao clicar em “Enviar e-mail vencimento”, será enviado e-mail de TODOS os produtos que irão vencer nos próximos 5 dias(configurável para quantos dias forem necessário) para os e-mails cadastrados em cada produto no momento do cadastro;





- Na aba “Carteira” é possível visualizar a carteira através do cpf ou cnpj que foi efetuado a compra do produto




- Mas primeiro é necessário efetuar uma compra clicando em comprar e digitando o nome do produto que deseja comprar no modal que irá aparecer;


- Ao pesquisar um produto é necessário digitar o cpf ou cnpj e a quantidade que deseja comprar ou vender;

- Assim que tentar efetuar uma compra ou venda será feito um verificação do produto e da conta do cliente para saber se tem o produto disponível no caso de compra ou se o cliente tem a quantidade disponível no caso de venda;




- Depois da operação feita basta repetir ou clicar no “X” para sair e ao tentar buscar por Cpf ou Cnpj irá aparecer o produto comprado conforme a imagem abaixo;



- E por fim é possível visualizar o extrato da compra na aba de “Extrato” e pesquisar pelo Cpf ou Cnpj e a data de operação;






Métodos:

- Métodos utilizados na tela de “Gestão de Produtos”: Investment.Portfolio.WebApp > Controllers > GestaoProdutosController

- Métodos utilizados na tela de “Carteira”: Investment.Portfolio.WebApp > Controllers > CarteiraClienteController

- Métodos utilizados na tela de “Extrato”: Investment.Portfolio.WebApp > Controllers > OperacoesCompraVendaController

