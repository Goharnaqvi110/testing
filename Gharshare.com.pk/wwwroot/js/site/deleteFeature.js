$(function () {
    $('#frmFeature').submit(function (event) {
        event.preventDefault(); // Prevent default form submission
        //debugger;
        var formId = 'frmFeature';
        var formData = new FormData($('#' + formId)[0]);

        var closeButton = $('.btn-close');
        $.ajax({
            url: '/admin/site/deletefeature',
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (data) {
                //debugger;                     
                var successMessage = "Feature deleted successfully!"
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
                window.location.reload();
            },
            error: function (xhr, status, error) {
                //debugger;
                var responseText = JSON.parse(xhr.responseText);
                swal.fire(
                    {
                        icon: 'error',
                        title: 'Error',
                        text: responseText.error,
                        showConfirmButton: false,
                        timer: 2000,
                    }
                );
            }
        });
    });

});