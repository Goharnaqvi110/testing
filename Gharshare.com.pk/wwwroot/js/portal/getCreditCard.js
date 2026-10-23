function getCreditCard(id) {
    //debugger;
    $('#cardProcessing').css('display', 'block');
    $.ajax({
        url: '/portal/getCreaditCard?propertyId=' + id,
        type: 'GET',
        success: function (data) {
            $('#cardProcessing').css('display', 'none');
            debugger;
            $('#propertyID').val(id);
            if (data != null) {
                $('#userCreditCardID').val(data.id);
                $('#propertyID').val(data.propertyId);
            }
            else {
                $('#userCreditCardID').val('');
            }
            $('.cardEntrySection').css('display', 'none');
            if (data != null) {
                if (data.cardNo != null) {
                    var cardNo = data.cardNo;
                    var lastFourDigits = '******' + cardNo.slice(-4); // Get the last four digits
                    $('#cardNo').text(lastFourDigits);
                }
                var expiryDate = data.month + '/' + data.year;
                $('#cardexpiry').text(expiryDate);
                //if (data.updatedOn != null) {
                //    var updatedOn = date.updatedOn //formatDateToDDMMYY(date.updatedOn);
                //    $('#cardUpdateDate').text(updatedOn);
                //}

                $('#cardHolderName').val(data.cardHolderName);
                var cardType;
                if (data.cardType == 1)
                    cardType = 'visa';
                else
                    cardType = 'express';

                $('#cardType').val(cardType);
                $('#cardNumber').val(data.cardNo);
                $('#month').val(data.month);
                $('#year').val(data.year);
                $('#chkUsedForPayment').prop('checked', data.isSelectedForPayment);
            }
            else {
                $('#cardNo').text('No credit card associated with this property');
                $('#cardexpiry').text('');
                $('#cardUpdateDate').text('');

                $('#cardHolderName').val('');
                $('#cardType').val('');
                $('#cardNumber').val('');
                $('#month').val('');
                $('#year').val('');
                $('#chkUsedForPayment').prop('checked', false);
            }
        },
        error: function (xhr, status, error) {
            // Handle error
            debugger;
            console.log(xhr);
        }
    });
}
