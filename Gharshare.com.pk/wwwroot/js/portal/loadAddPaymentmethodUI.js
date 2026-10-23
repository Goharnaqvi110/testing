function loadAddPaymentmethodUI(paymentMethod) { 
   //debugger;
    $.ajax({ 
        url: '/portal/addpaymentmethod?paymentMethod=' + paymentMethod,
        type: 'GET',        
        success: function (data) {             
            $('#lgmodalTitle').empty().html('Add New Payment Method');
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
