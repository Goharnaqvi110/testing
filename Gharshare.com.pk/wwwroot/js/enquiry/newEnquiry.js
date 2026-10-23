function newEnquiry() {    
     
    $.ajax({ 
        url: '/enquiry/newEnquiry',
        type: 'GET',         
        success: function (data) {
            //debugger;
            $('#enquiryModalTitle').empty().html('Send enquiry');
            $('#enquiryModalContainer').empty().html(data);
        },
        error: function (xhr, status, error) {
            // Handle error
            debugger;
            console.log(xhr);
        }
    });
}
