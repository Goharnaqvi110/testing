function sendLease2Tenant() {
    if ($(this).hasClass('disabled')) {
        return; // Do nothing if already disabled
    }

    var leaseId = $('#txtLeaseId').val();
    var formData = new FormData();
    formData.append("ID", leaseId);
    //debugger;
    if (formData != null) {
        // Ajax call to validate demo request starts
        $.ajax({
            url: '/lease/sendlease2Tenant',
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,
            success: function (result) {
                if (result) {
                    //debugger;                     
                    $('#btnSend').addClass('disabled');
                   // window.location.href = "/property/list";
                    swal.fire(
                        {
                            icon: 'success',
                            title: 'Success',
                            text: 'Lease agreement sent to tenant(s) successfully.',
                            showConfirmButton: false,
                            timer: 2000,
                        }                        
                    ); 
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
}
