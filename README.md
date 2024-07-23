SISTEMA DE GEST�O DE PORTF�LIO DE INVESTIMENTOS



Resumo:
-  O projeto foi desenvolvido em .Net Core 8 na linguagem C# utilizando banco de dados MySQL.


Passos para executar projeto:

- Para rodar o projeto basta clonar a aplica��o no git atrav�s do link �� ou abrir a pasta do projeto que foi enviado atrav�s do �� no Visual Studio e em seguida verificar se o projeto para rodar encontra � se no �IIS Express� conforme imagem abaixo:




Caso contr�rio basta clicar com bot�o direito do mouse em cima do projeto �Investment.Portfolio.WebApp� e selecionar a op��o �Set as Startup Project� que ir� aparecer a op��o. Feito isso basta clica no mesmo para rodar o projeto.


Obs: vale destacar 3 pontos que foram criados para efetuar os testes com o fluxo completo:

- Foi criado um frontend b�sico para possibilitar efetuar os cadastros e poder visualizar de forma mais �gil e pr�tica;

- Para inserir os dados foi criado um banco de dados e hospedado na nuvem, e toda a configura��o j� est� feita, ent�o basta rodar a aplica��o que j� ser� poss�vel visualizar e cadastrar os dados;

- Para efetuar o disparo de e-mail, foi criado um e-mail de teste chamado �contato_invest@hotmail.com� para fazer a autentica��o do remetente, e o mesmo tamb�m j� se encontra configurado, ent�o basta rodar a aplica��o e cadastrar um e-mail v�lido no campo e-mail do administrador na tela de cadastro de produtos para conseguir visualizar o e-mail.



Passos para utilizar a aplica��o:

- Ao rodar o projeto a tela inicial abaixo, caso a formata��o da p�gina esteja sem estilo de p�gina ou formata��o, limpe o cache ou tente executar em aba an�nima.




- O primeiro passo � cadastrar um produto clicando em  ;







- Em seguida preencha o formul�rio com todos os campos.

-----------EXEMPLO DE PREENCHIMENTO-----------------

. Produto: LCI XP (Nome Fantasia);

. Tipo Produto: LETRA DE CR�DITO IMOBLI�RIO (Tipo do produto por extenso));

. Especifica��o do produto: LETRA DE CR�DITO IMOBLI�RIO XP INC (Nome do produto sem abrevia��o);

Negocia��o: ex: Bovespa, BM&F, RENDA FIXA...;

Quantidade: 20;

Pre�o: 1000,00 (N�o colocar ponto no milhar);
�
Email Administrador: e-mail da pessoa que for receber o e-mail para testar;

Data Vencimento: est� definido para enviar o e-mail para o vencimento dos pr�ximos 5 dias, mas pode ser mudado atrav�s do appsettings;


- Ap�s salvar, voltar e atualizar a p�gina � poss�vel visualizar os dados no grid conforme a imagem abaixo:




- Na �ltima coluna � poss�vel efetuar a exclus�o clicando no �cone de lixeira e � poss�vel editar no �cone ao lado que ser� aberto a p�gina conforme a imagem abaixo bastando apenas alterar qualquer campo exceto o nome do produto;




- Ao clicar em �Enviar e-mail vencimento�, ser� enviado e-mail de TODOS os produtos que ir�o vencer nos pr�ximos 5 dias(configur�vel para quantos dias forem necess�rio) para os e-mails cadastrados em cada produto no momento do cadastro;





- Na aba �Carteira� � poss�vel visualizar a carteira atrav�s do cpf ou cnpj que foi efetuado a compra do produto




- Mas primeiro � necess�rio efetuar uma compra clicando em comprar e digitando o nome do produto que deseja comprar no modal que ir� aparecer;


- Ao pesquisar um produto � necess�rio digitar o cpf ou cnpj e a quantidade que deseja comprar ou vender;

- Assim que tentar efetuar uma compra ou venda ser� feito um verifica��o do produto e da conta do cliente para saber se tem o produto dispon�vel no caso de compra ou se o cliente tem a quantidade dispon�vel no caso de venda;




- Depois da opera��o feita basta repetir ou clicar no �X� para sair e ao tentar buscar por Cpf ou Cnpj ir� aparecer o produto comprado conforme a imagem abaixo;



- E por fim � poss�vel visualizar o extrato da compra na aba de �Extrato� e pesquisar pelo Cpf ou Cnpj e a data de opera��o;






M�todos:

- M�todos utilizados na tela de �Gest�o de Produtos�: Investment.Portfolio.WebApp > Controllers > GestaoProdutosController

- M�todos utilizados na tela de �Carteira�: Investment.Portfolio.WebApp > Controllers > CarteiraClienteController

- M�todos utilizados na tela de �Extrato�: Investment.Portfolio.WebApp > Controllers > OperacoesCompraVendaController

