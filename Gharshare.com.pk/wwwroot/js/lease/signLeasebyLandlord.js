function signLeasebyLandlord() {
    if ($(this).hasClass('disabled')) {
        return; // Do nothing if already disabled
    }
    //var leaseId = $('#txtLeaseId').val();     
    var formData = new FormData($('#frmLease')[0]);
    //formData.append("ID", leaseId);
    //debugger;
    if (formData != null) {
        var btnSave = $('#btnSave');         
        $('#btnSave').addClass('disabled');
        btnSave.addClass('loading');
        $("#stepalert").show();
        $('.card').css('height', '+=' + 90);
        // Ajax call to validate demo request starts
        $.ajax({
            url: '/lease/signLease',
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,            
            success: function (result) {
                if (result) {
                    //debugger;                     
                    $('#btnSave').addClass('disabled');
                    btnSave.removeClass('loading');
                    $('#stepalert').hide();
                    window.location.reload();
                    swal.fire(
                        {
                            icon: 'success',
                            title: 'Success',
                            text: 'Lease successfully signed.',
                            showConfirmButton: false,
                            timer: 2000,
                        }                        
                    ); 
                   // window.location.href = "/property/list";
                }
            }, error: function (xhr, status, error) {
                debugger;
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
