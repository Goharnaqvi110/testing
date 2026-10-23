$(document).ready(function () {
    $('#frmMessage').submit(function (event) {
        event.preventDefault();
        debugger;
        var formId = 'frmMessage';
        var formData = new FormData($('#' + formId)[0]);
       // console.log(formData);
        var message = $('#txtMessage').val();
        if (message != "") {
            $.ajax({
                url: "/enquiry/savenewEnquiry",
                type: "POST",
                data: formData,
                contentType: false,
                processData: false,
                success: function (result) {
                    $('#txtMessage').val('');                    
                    swal.fire(
                        {
                            icon: 'success',
                            title: 'Success',
                            text: 'Enquiry sent successfully.',
                            showConfirmButton: false,
                            timer: 2000,
                        }
                    );   
                },
                error: function (xhr, status, error) {
                    swal.fire(
                        {
                            icon: 'error',
                            title: 'Error',
                            text: 'Error sending message.',
                            showConfirmButton: false,
                            timer: 2000,
                        }
                    );
                }
            });
        }
        if(message == "") {
            $('#spanMessage').empty();
            $('#spanMessage').html('*Message is required');
        }
    });
    
    $('#txtMessage').on('input', function () {
        var message = $('#txtMessage').val().trim();
        if (message != "") {
            $('#spanMessage').html('');
        }
        else {
            $('#spanMessage').html('*Message is required');
        }
    });

    $('#ddlSelect').on('change', function () {
        var roomValue = $('#ddlSelect').val().trim();
        if (roomValue != "") {
            $('#spanRoom').html('');
        }
        else {
            $('#spanRoom').html('*Room is required');
        }
    });

    //for home page send enquiry section
    $('#ddlAbout').on('change', function () {
        debugger;
        $('#seAbout').html($('#ddlAbout').val() === "" ? "*" : "");
    });
});