function editPropertyPopup(propertyUid) {   
     
   // debugger;
    $.ajax({ 
        url: '/property/editproperty?propertyUid=' + propertyUid,
        type: 'GET',        
        beforeSend: function () {
            // Show the preloader before the AJAX request is sent
            $('#preloader').removeClass('d-none');
        },
        success: function (data) {            
            $('#preloader').addClass('d-none');
            $('#modalTitle').empty().html('Edit Property');
            $('#accountSettingsContainer').empty().html(data);
        },
        error: function (xhr, status, error) {
            // Handle error
            debugger;
            console.log(xhr);
        }
    });
}
