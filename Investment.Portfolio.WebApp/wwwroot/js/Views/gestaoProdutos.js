$(document).ready(function () {
    var produtos = new Produtos;
    /*produtos.enviarEmailVencimento();*/
    produtos.loadGrid();
});

var tableProdutos = null;

var Produtos = function () {
    var me = this;

    me.enviarEmailVencimento = function () {
        util.ajax.post(`../GestaoProdutos/EnvioEmail`, null, me.callSucessEmail, me.callBackError);
    }
    me.loadGrid = function () {
        util.ajax.post(`../GestaoProdutos/ListarProdutos`, null, me.callBackSuccess, me.callBackError);
    }
    me.callBackSuccess = function (data) {
        me.montarGrid(data);
    }
    me.callSucessEmail = function (result) {
        $("#idEnviarEmail").prop('disabled', false);
        $("#c-loader").addClass('d-none');
        alert(result.mensagem);
    }
    me.callSucessExcluir = function () {
        UtilModal.close();
        window.location.href = `../Home/Index`;
    }
    me.callBackError = function (result) {
        console.log(result.mensagem);
    }
    me.montarGrid = function (result) {
        $('#divListaInexistente').addClass('d-none');
        if (tableProdutos)
            tableProdutos.destroy();

        var trashIcon = '<svg xmlns="http://www.w3.org/2000/svg" width="18" height="18" class="bi bi-trash" viewBox="0 0 16 16"><path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z"/><path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"/></svg>';
        var editIcon = '<svg width="16px" height="18px" viewBox="0 0 16 18" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink"><defs><polygon id="path-1" points="10.078915 6.55164513e-06 14 6.55164513e-06 14 4.06176042 10.078915 4.06176042"></polygon></defs><g id="Tesouro-Direto" stroke="none" stroke-width="1" fill="none" fill-rule="evenodd"><g id="10.0-consultar-agendamentos-ALT" transform="translate(-1194.000000, -1166.000000)"><g id="Group-4-Copy-3" transform="translate(1195.000000, 1166.000000)"><polygon id="Fill-1" stroke="#09282A" stroke-width="0.5" fill="#09282A" points="0 2.12489375 0 16.9998938 14 16.9998938 14 7.43739375 13.3 7.43739375 13.3 16.2919146 0.7 16.2919146 0.7 2.83358125 7.7 2.83358125 7.7 2.12489375"></polygon><path d="M6.31589,10.4431708 L9.93209,4.1057125 L11.49834,5.02087917 L7.88249,11.3583375 L6.01384,12.8029833 L6.31589,10.4431708 Z M5.10384,14.3977958 L8.41869,11.8350458 L12.45454,4.76162917 L9.67554,3.13812917 L5.63969,10.2115458 L5.10384,14.3977958 Z" id="Fill-2" stroke="#09282A" stroke-width="0.5" fill="#09282A"></path><mask id="mask-2" fill="white"><use xlink:href="#path-1"></use></mask><g id="Clip-4"></g><path d="M11.035115,2.17901042 L11.612615,1.16644792 C11.733365,0.95465625 11.928665,0.803427083 12.161765,0.74003125 C12.394515,0.676989583 12.638815,0.70921875 12.848115,0.83140625 C13.280015,1.08392708 13.428415,1.64457292 13.178865,2.08161458 L12.601365,3.09417708 L11.035115,2.17901042 Z M13.785415,2.43578125 C14.227815,1.66051042 13.964265,0.66565625 13.198115,0.217989583 C12.827115,0.00159375 12.395215,-0.0561354167 11.980815,0.05578125 C11.566765,0.168052083 11.220615,0.436864583 11.006415,0.81228125 L10.078915,2.43826042 L12.857915,4.06176042 L13.785415,2.43578125 Z" id="Fill-3" stroke="#09282A" stroke-width="0.5" fill="#09282A" mask="url(#mask-2)"></path></g></g></g></svg>';

        $('#tbProdutos').removeClass('d-none');
        $.fn.dataTable.ext.classes.sLengthSelect = 'pagination-select w-100';
        tableProdutos = $('#tbProdutos').DataTable({
            data: result,
            lengthChange: true,
            lengthMenu: [[10, 20, 30, -1], ["10 Registros", "20 Registros", "30 Registros", "Tudo"]],
            createdRow: function (row, data, dataIndex, cells) {
                $(cells).addClass('x-table__text');
            },
            columns: [
                { "data": "idProduto" },
                { "data": "ativo" },
                { "data": "tipoProduto" },
                { "data": "especificacaoTitulo" },
                { "data": "negociacao" },
                { "data": "quantidadeDisponivel" },
                { "data": "preco" },
                { "data": "emailAdministrador" },
                { "data": "dataAlteracao" },
                { "data": "dataVencimentoFormatada" },
                { "className": "x-table__text--align-center" }
            ],
            columnDefs: [
                {
                    "targets": [10],
                    "orderable": false,
                    "render": function (data, type, row, meta) {
                        var str = '../GestaoProdutos/CadastrarEditarProduto';
                        return "<label class='offset-2' style='cursor: pointer;' title='Excluir' onclick='ExcluirProduto(" + row.idProduto + ")'>" + trashIcon + "</label><a href='" + (str + "?idProduto=" + row.idProduto) + "' class='offset-2' style='cursor: pointer;' title='Editar'>" + editIcon + "</a>"
                    }
                }
            ],
            order: [[2, "asc"]],
            dom: 'lpt',
            language: {
                sEmptyTable:
                    '<div class="row">' +
                    '<div id="divListaInexistente" name="divAlerta" class= "alert alert-info alert-dismissible fade show" role="alert" >' +
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
       var produto=$('#idNomeProduto').val();
        util.ajax.post(`../GestaoProdutos/ListarProdutos?produto=${produto}`, null, me.callBackSuccess, me.callBackError);
    }
    me.excluir = function (id) {
        util.ajax.post(`../GestaoProdutos/DeletarProduto?codProduto=${id}`, null, me.callSucessExcluir, me.callBackError);
    }
}
function BuscarListaProduto() {
    var produtos = new Produtos;
    produtos.pesquisar();
};
function ExcluirProduto(id) {
    var htmlExcluir = `
                        <div class="d-flex justify-content-evenly">
                            <p class="h4">Deseja continuar com a exclusão?</p>
                        </div>
                        <div class="modal-footer">
                        <button type="button" class="mx-4" id="modalBtnConfirmar" onclick="ConfirmaExclusao(${id})" style="font-size: 12px;">Confirmar</button>
                <button type="button" id="modalBtnCancelar"  data-dismiss="modal" style="font-size: 12px;">Voltar</button>
                </div>
                    `;

    UtilModal.open(
        "Exclusão",
        htmlExcluir,
        () => {
            AgoraModal.esconderReturn();
            AgoraModal.esconderErro();
        }, true, true
    );
};
function ConfirmaExclusao(id) {
    var produtos = new Produtos;
    produtos.excluir(id);
};
function EnviarEmail() {
    $("#idEnviarEmail").prop('disabled', true);
    $("#c-loader").removeClass('d-none');
    var produtos = new Produtos;
    produtos.enviarEmailVencimento();
};