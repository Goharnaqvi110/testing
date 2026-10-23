$(function () {
    $('#frmCard').submit(function (event) {
        event.preventDefault(); // Prevent default form submission
        debugger;
        var formId = 'frmCard';
        var formData = new FormData($('#' + formId)[0]);         
        $('#btnSaveCard').addClass('disabled');
        var closeButton = $('.btn-close');
            $.ajax({
                url: '/portal/savecard',
                type: 'POST',
                data: formData,
                processData: false,
                contentType: false,
                success: function (data) {
                    var successMessage = "User card successfully saved!"
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
                    var errorMessage = "Error adding user card !"
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
        //}
       // else {
        //    swal.fire(
        //        {
        //            icon: 'error',
        //            title: 'Validation error',
        //            text: 'All fields required.Please fill in the form completly',
        //            showConfirmButton: false,
        //            timer: 2000,
        //        }
        //    );

        //}
    });

});