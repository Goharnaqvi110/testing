function loadlease2renew(leaseId) { 

    //debugger;
    $.ajax({ 
        url: '/lease/loadlease2renew?leaseId=' + leaseId,
        type: 'GET',
        beforeSend: function () {
            // Show the preloader before the AJAX request is sent
            $('#preloader').removeClass('d-none');
        },
        success: function (data) {
            $('#preloader').css('display', 'none');
            //debugger
            $('#modalTitle').empty().html('Renew Lease');
            $('#accountSettingsContainer').empty().html(data);
        },
        error: function (xhr, status, error) {
            // Handle error
            debugger;
            console.log(xhr);
        }
    });
}
