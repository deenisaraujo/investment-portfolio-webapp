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

    open: (title,body, action, btnConfirmarCancelar = true, btnConfirmar = true) => {
        UtilModal.setTitle(title);
        UtilModal.setBody(body);

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