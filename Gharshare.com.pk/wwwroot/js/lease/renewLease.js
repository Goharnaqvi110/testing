$('#frmLease').submit(function (event) {
    event.preventDefault(); // Prevent default form submission 
   // debugger;
    var formId = 'frmLease';
    var formData = new FormData($('#' + formId)[0]);
    //debugger;
    if (formData != null) {
        // Ajax call to validate demo request starts
        var closeButton = $('.btn-close');
        $('#btnRenew').addClass('disabled');
        $("#stepalert").show();
        debugger;
        $.ajax({
            url: '/lease/renewLease',
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            success: function (result) {
                if (result) {
                    $("#stepalert").hide();
                    //debugger;
                    // window.location.href = "/property/list";
                    swal.fire(
                        {
                            icon: 'success',
                            title: 'Success',
                            text: 'Lease agreement renewed successfully.',
                            showConfirmButton: false,
                            timer: 2000,
                        }
                    );
                    closeButton.trigger('click');
                    // window.location.href = "/property/list";
                }
            }, error: function (xhr, status, error) {
                //debugger;
                // Handle the error response                                     
                swal.fire(
                    {
                        icon: 'error',
                        title: 'Error',
                        text: xhr.responseText,
                        showConfirmButton: false,
                        timer: 2000,
                    }
                );
            }
        });
        // Ajax call ends
    }
})
