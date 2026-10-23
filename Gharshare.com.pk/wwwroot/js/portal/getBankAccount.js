function getBankAccount(id) { 
    //debugger;
    $('#accountProcessing').css('display', 'block');
    $.ajax({ 
        url: '/portal/getBankAccount?leaseId=' + id,
        type: 'GET',
        success: function (data) {
            $('#accountProcessing').css('display', 'none');
            //debugger;
            $('#txtLeaseId').val(data.id);
            $('.bankAccountEntrySection').css('display', 'none');
            if (data.bankName != null) {                
                $('#bankname').text(data.bankName);
                var accountNo = data.accountNo;
                var lastFourDigits ='******'+accountNo.slice(-4); // Get the last four digits
                $('#account').text(lastFourDigits);
            }
            else {
                $('#bankname').text('No bank account associated with this property');
                $('#account').text('');
            }
            //$('#txtBank').val(data.bankName);
            //$('#txtAccTitle').val(data.accountTitle);
            //$('#txtBranch').val(data.branch);
            //$('#txtAccNo').val(data.accountNo);
        },
        error: function (xhr, status, error)
        {
            // Handle error
            debugger;
            console.log(xhr);
        }
    });
}
