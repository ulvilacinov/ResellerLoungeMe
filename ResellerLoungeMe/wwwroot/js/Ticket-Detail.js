$(document).ajaxStart(function () {
    $(".spinner").show();
});

$(document).ajaxStop(function () {
    $(".spinner").attr("style", "display: none !important");
});

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
                }
            });
        }
    });
}

function SendPass() {
    var isEmail = $("#emailChb").is(":checked");
    var isSms = $("#smsChb").is(":checked");
    var lang = "";
    if (isEmail || isSms) {
        Swal.fire({
            title: 'Please select language',
            html: "<br>" +
                '<button type="button" role="button" tabindex="0" class="btn bg-gradient-dark mr-3 tr">' + 'Turkish' + '</button>' +
                '<button type="button" role="button" tabindex="0" class="btn bg-gradient-light en">' + 'English' + '</button>',
            showCancelButton: true,
            showConfirmButton: false
        }).then((result) => {
            debugger;
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
                        )
                    }
                });
            }

        });

        $(document).on('click', '.tr', function () {
            lang = "tr";
            swal.clickConfirm();
        });
        $(document).on('click', '.en', function () {
            lang = "en";
            swal.clickConfirm();
        });
    } else {
        Swal.fire('Please select SMS or E-Mail');
    }


}