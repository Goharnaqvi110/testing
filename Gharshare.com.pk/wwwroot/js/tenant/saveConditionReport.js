function saveConditionReport() {
    debugger;
    if ($(this).hasClass('disabled')) {
        return; // Do nothing if already disabled
    }     
    var formData = new FormData($('#frmreport')[0]);     
    //debugger;
    if (formData != null) {
        var btnSave = $('#btnSave');
        $('#btnSave').addClass('disabled');
        btnSave.addClass('loading');
        $("#stepalert").show();         
        // Ajax call to validate demo request starts
        $.ajax({
            url: '/tenant/savereport',
            type: 'POST',
            data: formData,
            contentType: false,
            processData: false,            
            success: function (filePath) {
                //debugger;
                if (filePath !="") {
                    //debugger;
                    $('#stepalert').hide();
                    window.location.href = "/portal/document?filePath=" + filePath;
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
