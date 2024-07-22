$(document).ready(function () {
    var extrato = new Extrato;
    extrato.loadGrid();
});
var tableExtrato = null;
var Extrato = function () {
    var me = this;

    me.loadGrid = function () {
        util.ajax.post(`../CarteiraCliente/CarregarExtrato`, null, me.callBackSuccess, me.callBackError);
    }
    me.callBackSuccess = function (data) {
        me.montarGrid(data);
    }
    me.callBackError = function (error) {
        console.log(error);
    }
    me.montarGrid = function (result) {
        $('#divListaExtratoInexistente').addClass('d-none');
        if (tableExtrato)
            tableExtrato.destroy();

        $('#tbExtrato').removeClass('d-none');
        $.fn.dataTable.ext.classes.sLengthSelect = 'pagination-select w-100';
        tableExtrato = $('#tbExtrato').DataTable({
            data: result,
            lengthChange: true,
            lengthMenu: [[10, 25, 50, -1], ["10 Registros", "25 Registros", "50 Registros", "Tudo"]],
            createdRow: function (row, data, dataIndex, cells) {
                $(cells).addClass('x-table__text');
            },
            columns: [
                { "data": "nota" },
                { "data": "cpfCnpj" },
                { "data": "ativo" },
                { "data": "tipoProduto" },
                { "data": "negociacao" },
                { "data": "tipoOperacao" },
                { "data": "especificacaoTitulo" },
                { "data": "quantidade" },
                { "data": "preco" },
                { "data": "valorOperacao" },
                { "data": "dataOperacao" }
            ],
            order: [[10, "asc"]],
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
        var cpfCnpj = $('#idCpfCnpjExtrato').val() == '' ? 0 : $('#idCpfCnpjExtrato').val();
        var dataExtrato = $('#idDataExtrato').val() == '' ? "01/01/0001 00:00:00" : $('#idDataExtrato').val();
        util.ajax.post(`../CarteiraCliente/CarregarExtrato?cpfCnpj=${cpfCnpj}&dataExtrato=${dataExtrato}`, null, me.callBackSuccess, me.callBackError);
    }
}
function Buscar() {
    var extrato = new Extrato;
    extrato.pesquisar();
};
