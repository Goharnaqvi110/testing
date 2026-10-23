function deleteBill(id) { 
   //debugger;
    $.ajax({ 
        url: '/portal/deletebill?id=' + id,
        type: 'GET',
        beforeSend: function () {
            // Show the preloader before the AJAX request is sent
            $('#preloader').removeClass('d-none');
        },
        success: function (data) {
            $('#preloader').css('display', 'none');            
            $('#lgmodalTitle').empty().html('Delete bill');
            $('#lgmodalContainer').empty().html(data);
        },
        error: function (xhr, status, error)
        {
            // Handle error
            debugger;
            console.log(xhr);
        }
    });
}
