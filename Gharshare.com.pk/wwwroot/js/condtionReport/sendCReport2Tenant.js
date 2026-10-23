function sendReport(reportId) {
    //debugger;
    if (reportId != null) {
        // Ajax call to validate demo request starts
        $.ajax({
            url: '/conditionreport/sendreport2tenant?reportid=' + reportId,
            success: function (result) {
                if (result) {
                    //debugger;
                    $('#sendReport').prop('disabled', true);
                    window.location.href = "/property/list";
                    swal.fire(
                        {
                            icon: 'success',
                            title: 'Success',
                            text: 'Condition report sent to tenant dashboard successfully.',
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
