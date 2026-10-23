function loadEnquiryinPopup(enquiryId) {    
     
    $.ajax({ 
        url: '/enquiry/loadenquiry?enquiryid=' + enquiryId,
        type: 'GET',         
        success: function (data) {
            //debugger;
            $('#enquiryModalTitle').empty().html('Enquiry');
            $('#enquiryModalContainer').empty().html(data);
        },
        error: function (xhr, status, error) {
            // Handle error
            debugger;
            console.log(xhr);
        }
    });
}
