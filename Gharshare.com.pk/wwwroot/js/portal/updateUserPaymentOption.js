$(function () {
    $('#frmPaymentOption').submit(function (event) {
        event.preventDefault(); // Prevent default form submission
        //debugger;
        var formId = 'frmPaymentOption';
        var formData = new FormData($('#' + formId)[0]); 
        $('#btnUpdate').addClass('disabled');         
            $.ajax({
                url: '/portal/updateUserPaymentOption',
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function (data) {
                    var successMessage = "User payment option successfully updated!"
                    swal.fire(
                        {
                            icon: 'success',
                            title: 'Success',
                            text: successMessage,
                            showConfirmButton: false,
                            timer: 2000,
                        }
                    );
                    closeButton.trigger('click');
                },
                error: function (xhr, status, error) {
                    var errorMessage = "Error updating user payment option!"
                    swal.fire(
                        {
                            icon: 'error',
                            title: 'error',
                            text: errorMessage,
                            showConfirmButton: false,
                            timer: 2000,
                        }
                    );
                }
            });
    });
});