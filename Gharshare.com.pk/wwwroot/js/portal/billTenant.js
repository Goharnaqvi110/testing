function billTenant(expenseid, leaseid) { 
    var formData = new FormData();  
    formData.append("expenseid", expenseid);
    formData.append("leaseid", leaseid);
   //debugger;
    $.ajax({ 
        url: '/portal/billtenant', /*?=expenseid' + expenseid + '&leaseid' + leaseid,*/
        type: 'POST',         
        data: formData,
        processData: false,  // Prevent jQuery from automatically transforming the data
        contentType: false,  // Prevent jQuery from automatically setting the content type
        beforeSend: function () {
            // Show the preloader before the AJAX request is sent
            $('#preloader').removeClass('d-none');
        },
        success: function (data) {
            $('#preloader').css('display', 'none');            
            $('#lgmodalTitle').empty().html('Bill the expense to tenant');
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
