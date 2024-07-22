var tableCarteiraProduto = null;
var idProdutoModal = null;
var Carteira = function () {
    var me = this;
    me.callBackSuccess = function (data) {
        me.montarGrid(data);
        $("#idGridCarteira").removeClass('d-none');
    }
    me.callBackError = function (error) {
        console.log(error);
    }
    me.montarGrid = function (result) {
        $('#divListaCarteiraProdutoInexistente').addClass('d-none');
        if (tableCarteiraProduto)
            tableCarteiraProduto.destroy();

        $('#tbCarteiraProduto').removeClass('d-none');
        $.fn.dataTable.ext.classes.sLengthSelect = 'pagination-select w-100';
        tableCarteiraProduto = $('#tbCarteiraProduto').DataTable({
            data: result,
            lengthChange: true,
            lengthMenu: [[10, 25, 50, -1], ["10 Registros", "25 Registros", "50 Registros", "Tudo"]],
            createdRow: function (row, data, dataIndex, cells) {
                $(cells).addClass('x-table__text');
            },
            columns: [
                { "data": "ativo" },
                { "data": "tipoProduto" },
                { "data": "quantidade" },
                { "data": "preco" },
                { "data": "posicao" }
            ],
            order: [[1, "asc"]],
            dom: 'lpt',
            language: {
                sEmptyTable:
                    '<div class="row">' +
                    '<div id="divListaCarteiraProdutoInexistente" name="divAlerta" class= "alert alert-info alert-dismissible fade show" role="alert" >' +
                    '<div id="divAlertaMensagem" name="divAlertaMensagem">A pesquisa não retornou nenhum resultado!</div>' +
                    '</div >' +
                    '</div > ',
                sInfo: '',
                sInfoEmpty: 'Mostrando 0 até 0 de 0 registros',
                sInfoFiltered: '(Filtrados de _MAX_ registros)',
                sInfoPostFix: '',
                sInfoThousands: '.',
                decimal: ',',
                thousands: '.',
                sLengthMenu: '_MENU_',
                sLoadingRecords: 'Carregando...',
                sProcessing: 'Processando...',
                sZeroRecords: 'Nenhum registro encontrado',
                sSearch: 'Filtrar',
                oPaginate: {
                    sNext: '',
                    sPrevious: '',
                    sFirst: '',
                    sLast: ''
                },
                oAria: {
                    sSortAscending: ': Ordenar colunas de forma ascendente',
                    sSortDescending: ': Ordenar colunas de forma descendente'
                }
            }
        });
    }
    me.pesquisar = function () {
        var cpfCnpj =$('#idCpfCnpj').val();
        util.ajax.post(`../CarteiraCliente/ListarCarteira?cpfCnpj=${cpfCnpj}&idProduto=${0}`, null, me.callBackSuccess, me.callBackError);
    }
}
function Buscar() {
    var carteira = new Carteira;
    carteira.pesquisar();
};

function CompraVenda() {
    UtilModal.open(
        "Período",
        () => {
            AgoraModal.esconderReturn();
            AgoraModal.esconderErro();
        }, true, true
    );
}
function BuscarProduto() {
    var produto = $('#idNomeProdModal').val();
    util.ajax.post(`../GestaoProdutos/ListarProdutos?produto=${produto}`, null, preecherCamposModal, erro);
}
function ConfirmarCompraVenda(tipoOperacao) {
    var ordem = {
        IdProduto: idProdutoModal,
        CpfCnpj: $("#idCpfCnpj").val(),
        TipoOperacao: tipoOperacao,
        Quantidade:$("#idQuantidadeModal").val(),
    }
    util.ajax.post(`../OperacoesCompraVenda/CompraVendaProduto`, ordem, sucessoCompraVenda, erroCompraVenda);
}
function sucessoCompraVenda(result) {
    if (result.status == 200) {
        $('#returnModal').addClass('d-none');
        $('#errorModal').removeClass('d-none');
        $('#errorMsg').text(result.mensagem)
    }
    else {
        $('#errorModal').addClass('d-none');
        $('#returnModal').removeClass('d-none');
        $('#returnMsg').text(result.mensagem)
    }

}
function erroCompraVenda(result) {
    $("#returnModal").removeClass('d-none');
    $("#returnMsg").text(result.mensagem)
}
function preecherCamposModal(result) {
    $("#infoProduto").removeClass('d-none');
    idProdutoModal = result[0].idProduto;
    $("#idAtivoModal").text(result[0].ativo);
    $("#idQuantidadeDisponivelModal").text(result[0].quantidadeDisponivel);
}
function erro(result) {
    
}