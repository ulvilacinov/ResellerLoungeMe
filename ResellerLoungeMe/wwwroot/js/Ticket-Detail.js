$(document).ajaxStart(function () {
    $(".spinner").show();
});

$(document).ajaxStop(function () {
    $(".spinner").attr("style", "display: none !important");
});

var lang = "";
function Cancel() {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonText: "Yes, cancel it!",
        cancelButtonText: "No",
    }).then(function (result) {
        if (result.value) {
            $.ajax("/Ticket/Cancel?id=" + ticketId, { type: "POST" }).done(function (data) {
                if (data) {
                    Swal.fire(
                        "Cancelled!",
                        "Your ticket has been cancelled.",
                        "success"
                    );
                    $(".buttons-row").html('<div class="alert alert-danger text-white font-weight-bold" role="alert">This ticket is cancelled!</div >');
                } else {
                    Swal.fire(
                        "Error",
                        "Something went wrong",
                        "error"
                    );
                }
            });
        }
    });
}

function SendPass() {
    var isEmail = $("#emailChb").is(":checked");
    var isSms = $("#smsChb").is(":checked");
   
    if (isEmail || isSms) {
        Swal.fire({
            title: 'Please select language',
            html: "<br>" +
                '<button type="button" role="button" tabindex="0" class="btn bg-gradient-dark mr-3 tr">' + 'Turkish' + '</button>' +
                '<button type="button" role="button" tabindex="0" class="btn bg-gradient-light en">' + 'English' + '</button>',
            showCancelButton: true,
            showConfirmButton: false
        }).then((result) => {
            if (result.isConfirmed) {
                var shareTicket = {
                    email: isEmail,
                    phone: isSms,
                    lang: lang
                };

                $.ajax({
                    type: "POST",
                    url: "/Ticket/SendPass?id=" + ticketId,
                    data: {
                        ticket: shareTicket
                    }
                }).done(function (data) {
                    if (data) {
                        Swal.fire(
                            "Successfull!",
                            "Your ticket has been sent.",
                            "success"
                        );
                    } else {
                        Swal.fire(
                            "Error",
                            "Something went wrong",
                            "error"
                        );
                    }
                });
            }

        });
    } else {
        Swal.fire('Please select SMS or E-Mail');
    }
}

function PrintPass() {

    //get card inner html
    var element = $(".card.shadow-lg").clone();
    // find buttons from cards html
    var buttons = element.find(".row.buttons-row");
    // remote buttons row
    buttons.remove();

    var mywindow = window.open('', 'PRINT', 'height=400,width=600');

    mywindow.document.write('<html><head><title>' + document.title + '</title>');
    mywindow.document.write('</head><body >');
    mywindow.document.write('<h1>' + document.title + '</h1>');
    mywindow.document.write(element[0].innerHTML);
    mywindow.document.write('</body></html>');

    mywindow.document.close(); // necessary for IE >= 10
    mywindow.focus(); // necessary for IE >= 10*/

    return true;
}

$(document).on('click', '.tr', function () {
    lang = "tr";
    swal.clickConfirm();
});
$(document).on('click', '.en', function () {
    lang = "en";
    swal.clickConfirm();
});