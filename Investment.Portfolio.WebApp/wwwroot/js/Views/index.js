$(document).ready(function () {
    onClickGestaoProdutos();
});
function onClickGestaoProdutos() {
    $("#idGestaoProdutos").removeClass("d-none");
    $("#idCarteira").addClass("d-none");
    $("#idExtrato").addClass("d-none");

    $("#menuGestaoProdutos").addClass("active");
    $("#menuCarteira").removeClass("active");
    $("#menuExtrato").removeClass("active");
}

function onClickCarteira() {
    $("#idCarteira").removeClass("d-none");
    $("#idGestaoProdutos").addClass("d-none");
    $("#idExtrato").addClass("d-none");

    $("#menuCarteira").addClass("active");
    $("#menuGestaoProdutos").removeClass("active");
    $("#menuExtrato").removeClass("active");
}

function onClickExtrato() {
    $("#idGestaoProdutos").addClass("d-none");
    $("#idCarteira").addClass("d-none");
    $("#idExtrato").removeClass("d-none");

    $("#menuExtrato").addClass("active");
    $("#menuCarteira").removeClass("active");
    $("#menuGestaoProdutos").removeClass("active");
}