var UtilModal = UtilModal || {};

$(document).ready(function () {
    _modalBtnConfirmar.hide();
    _modalBtnCancelar.hide();

    $(".modalBtnClose").click(function () {
        UtilModal.close();
    });

    $("#modalBtnConfirmar").click(function () {
        _confirmar();
    });

});

var _modal = $("#modal");
var _modalTitle = $("#modalTitle");
var _modalBody = $("#modalBody");
var _modalBtnConfirmar = $("#modalBtnConfirmar");
var _modalBtnCancelar = $("#modalBtnCancelar");
var _modalError = $("#errorModal");
var _modalErrorMsg = $("#errorMsg");
var _modalReturn = $("#returnModal");
var _modalReturnMsg = $("#returnMsg");
var _confirmar;


UtilModal = {
    setTitle: (title) => _modalTitle.html(title),

    setBody: (body) => _modalBody.html(body),

    setError: (msgError) => _modalErrorMsg.html(msgError),

    setReturn: (msgReturn) => _modalReturnMsg.html(msgReturn),

    mostrarErro: () => _modalError.css({ display: "block" }),

    esconderErro: () => _modalError.css({ display: "none" }),

    mostrarReturn: () => _modalReturn.css({ display: "block" }),

    esconderReturn: () => _modalReturn.css({ display: "none" }),

    trocarNomeBtnConfirmar: (nome) => _modalBtnConfirmar.html(nome),

    open: (title, action, btnConfirmarCancelar = true, btnConfirmar = true) => {
        UtilModal.setTitle(title);
        UtilModal.setBody(`                        
                       <div class="col-lg-12">
    <div class="row">
	            <div class="col-md-8 mt-2">
                    <div class="form-group">
                        <label class="col-form-label-xl">Nome Produto</label>
                        <input type="text" id="idNomeProdModal" place title="preencha o Nome do Produto">
                    </div>
                </div>
                <div class="col-md-1 mt-5 pt-5">
                    <div class="col-md-1 align-self-end">
                        <a href="#" class="style-button" style="padding: 6px 33px !important;background-color: #000!important;color:#fff!important;" onclick="BuscarProduto()">Buscar</a>
                    </div>
                </div>
                </div>
                <div class="row d-none" id="infoProduto">
                    <div class="col-md-2 mt-2">
                        <div class="form-group">
                            <label class="col-form-label-xl">Cpf ou Cnpj</label>
                        <input type="text" id="idCpfCnpj" place title="preencha o Cpf ou Cnpj">
                        </div>
                    </div>
                    <div class="col-md-4 mt-2" >
                        <div class="form-group">
                            <label class="col-form-label-xl" style="text-align: center;">Ativo</label>
                            <span id="idAtivoModal" class="textModal">-</span>
                        </div>
                    </div>
                    <div class="col-md-3 mt-2">
                        <div class="form-group">
                            <label class="col-form-label-xl" style="text-align: center;">Disponível</label>
                            <span id="idQuantidadeDisponivelModal" class="textModal">-</span>
                        </div>
                    </div>
                    <div class="col-md-2 mt-2">
                        <div class="form-group">
                            <label class="col-form-label-xl" style="text-align: center;">Quantidade</label>
                            <input type="text" id="idQuantidadeModal" place title="preencha a quantidade">
                        </div>
                    </div>
                 
                 <div class="modal-footer">
                <button type="button" class="mx-4" id="modalBtnComprar" onclick="ConfirmarCompraVenda(0)" style="font-size: 12px;background-color:seagreen; color:white">Comprar</button>
                <button type="button" id="modalBtnVender" data-dismiss="modal" onclick="ConfirmarCompraVenda(1)" style="font-size: 12px;background-color:red; color:white">Vender</button>
            </div>
             </div>`);

        _confirmar = action;

        if (btnConfirmarCancelar)
            _modalBtnCancelar.show();
        if (btnConfirmar)
            _modalBtnConfirmar.show();

        if (!btnConfirmarCancelar && !btnConfirmar)
            $(".modal-footer").hide();

        if (btnConfirmarCancelar && btnConfirmar)
            $(".modal-footer").show();

        _modal.addClass("show");
        _modal.css({ display: "block" });

    },

    close: () => {
        _modal.removeClass("show");
        _modal.css({ display: "none" });
        UtilModal.esconderErro();
        UtilModal.esconderReturn();
        _modalBtnConfirmar.html("Confirmar");
        _modalBtnCancelar.html("Voltar");
    }
}