function loadAccountSettings() {    
    var userId = $('#txtUserId').val();     
   //debugger;
    $.ajax({ 
        url: '/profile/accountsettings?userId=' + userId,
        type: 'GET',
        beforeSend: function () {
            // Show the preloader before the AJAX request is sent
            $('#preloader').removeClass('d-none');
        },
        success: function (data) {
            $('#preloader').css('display', 'none');
            //debugger
            $('#modalTitle').empty().html('Edit My Account');
            $('#accountSettingsContainer').empty().html(data);
        },
        error: function (xhr, status, error) {
            // Handle error
            debugger;
            console.log(xhr);
        }
    });
}
