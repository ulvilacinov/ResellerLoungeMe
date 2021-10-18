
$("#Terminals").on("change", function () {
    var terminalID = $("#Terminals option:selected").val();
    if (terminalID == '') {
        $("#lounges").find(".lounge-item").show();
        return;
    }
    $("#lounges").find(".lounge-item[data-terminal!='" + terminalID + "']").hide();
    $("#lounges").find(".lounge-item[data-terminal='" + terminalID + "']").show();
});