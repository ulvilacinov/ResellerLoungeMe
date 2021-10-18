$(document).ready(function () {

    $("#Airports").kendoAutoComplete({
        dataSource: {
            type: "json",
            serverFiltering: true,
            transport: {
                read: "Airport/GetAirports",
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
        template: "<a href='Airport/Lounges/#: data.value #'>#: data.text#</a>",
        minLength: 3,
    });

});