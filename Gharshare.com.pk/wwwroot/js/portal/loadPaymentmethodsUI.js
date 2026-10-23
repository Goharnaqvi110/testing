function loadPaymentmethodsUI() { 
   //debugger;
    $.ajax({ 
        url: '/portal/selectpaymentoption',
        type: 'GET',        
        success: function (data) {             
            $('#lgmodalTitle').empty().html('Please select your preferred payment method');
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
