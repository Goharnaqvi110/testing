function rejectApplication(applicationId) { 
    $('#btnReject').addClass('disabled');
    debugger;
    $.ajax({ 
        url: '/application/updateApplicationStatus?statusId=3 &applicationId=' + applicationId,
        type: 'GET',        
        success: function (result) {
            swal.fire(
                {
                    icon: 'success',
                    title: 'Success',
                    text: 'The application has successfully been rejected',
                    showConfirmButton: false,
                    timer: 2000,
                }
            );
        },
        error: function (xhr, status, error) {
            // Handle error
            debugger;
            console.log(xhr);
        }
    });
}
