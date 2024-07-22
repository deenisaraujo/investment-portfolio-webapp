var idAssunto = 0;
$(function () {
    var cadastrarEditarProduto = new CadastrarEditarProduto();
    cadastrarEditarProduto.carregarTela();
});

function Salvar() {
    var cadastrarEditarProduto = new CadastrarEditarProduto();
    cadastrarEditarProduto.salvar();
};
var CadastrarEditarProduto = function () {

    idProduto = util.URL.getParam("idProduto");

    var me = this;

    me.carregarTela = function () {
        $("#txtProduto").prop('disabled', false);
        if (idProduto != '')
            util.ajax.post(`../GestaoProdutos/ListarProdutos?idProduto=` + idProduto, null, me.preecherCampos, me.erroRequest);
    }
    me.preecherCampos = function (result) {
        $("#txtProduto").prop('disabled', true);
        $("#txtProduto").val(result[0].ativo);
        $("#txtTipo").val(result[0].tipoProduto);
        $("#txtEspecProduto").val(result[0].especificacaoTitulo);
        $("#txtNegociacao").val(result[0].negociacao);
        $("#txtQuantidade").val(result[0].quantidadeDisponivel);
        $("#txtPreco").val(result[0].preco.toString().replace('.', ','));
        $("#txtEmail").val(result[0].emailAdministrador);
        $("#txtVencimento").val(result[0].dataVencimento);
    }
    me.salvar = function () {
        var produto = {
            IdProduto: idProduto != '' ? idProduto : '0',
            Ativo: $("#txtProduto").val(),
            TipoProduto: $("#txtTipo").val(),
            EspecificacaoTitulo: $("#txtEspecProduto").val(),
            Negociacao: $("#txtNegociacao").val(),
            Quantidade: $("#txtQuantidade").val(),
            Preco: $("#txtPreco").val().toString().replace(',', '.'),
            EmailAdministrador: $("#txtEmail").val(),
            DataVencimento: $("#txtVencimento").val()
        }
        util.ajax.post('../GestaoProdutos/InserirAlterarProduto', produto, me.sucessoSalvar, me.erroSalvar);
    }
    me.sucessoSalvar = function (result) {
        $('#divSucesso').removeClass('d-none');
        $('#msgSucesso').text(result.mensagem);
    }
    me.erroSalvar = function (result) {
        $('#divErro').removeClass('d-none');
        $('#msgErro').text(result.mensagem);
    }
    me.erroRequest = function (erro) {
        console.log(erro);
    }
}