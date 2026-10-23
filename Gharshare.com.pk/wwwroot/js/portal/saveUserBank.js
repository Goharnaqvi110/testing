$(function () {
    $('#frmBank').submit(function (event) {
        event.preventDefault(); // Prevent default form submission
        //debugger;
        var formId = 'frmBank';
        var formData = new FormData($('#' + formId)[0]); 
        $('#btnAdd').addClass('disabled');
        var closeButton = $('.btn-close');
            $.ajax({
                url: '/portal/saveUserBankAccount',
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function (data) { 
                    $('#accountProcessing').css('display', 'none');
                    var successMessage = "User bank account successfully added!"
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
                    var errorMessage = "Error updating user bank account !"
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