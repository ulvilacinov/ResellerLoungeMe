// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {



    //create AutoComplete UI component
    $("#airports").kendoAutoComplete({
        dataSource: {
            type: "json",
            serverFiltering: true,
            transport: {
                read: "Airports/GetAirports",
                parameterMap: function (options, operation) {
                    if (operation == "read" && options.filter.filters.length > 0) {
                        return { searchKey: options.filter.filters[0].value };
                    }
                }
            }
        },
        filter: "contains",
        placeholder: "Select airport...",
        dataTextField: "text",
        dataValueField: "value",
        template: "<a href='Airports/Lounges/#: data.value #'>#: data.text#</a>",
        minLength: 3,
    });

});


$("#Terminals").on("change", function () {
    var terminalID = $("#Terminals option:selected").val();
    if (terminalID == '') {
        $("#lounges").find(".lounge-item").show();
        return;
    }
    $("#lounges").find(".lounge-item[data-terminal!='" + terminalID + "']").hide();
    $("#lounges").find(".lounge-item[data-terminal='" + terminalID + "']").show();

});