function selectUnselectPlan(radio, planName, monthlyCharges, upFrontCharges, address) {
    //debugger;
    if (radio.checked) {
        $('.card').css('border', 'none');
        $(radio).closest('.card').css('border', '1px solid red');
        $('#title').text(planName);
        // $('#address').val(address);
        var price;
        if (upFrontCharges > 0) {
            price = 'Rs ' + upFrontCharges + '+ Rs ' + monthlyCharges;
        }
        else {
            price = 'Rs ' + monthlyCharges;
        }
        $('#price').text(price);
        var monthly = '*after 3 months billed ' + monthlyCharges + '/month'
        $('#monthly').text(monthly);

        var gst
        if (upFrontCharges > 0) {
            gst = (upFrontCharges + monthlyCharges) * 18 / 100;
        }
        else {
            gst = monthlyCharges * 18 / 100;
        }
        $('#gst').text(gst);

        var total
        if (upFrontCharges > 0) {
            total = upFrontCharges + monthlyCharges + gst;
        }
        else { total = monthlyCharges + gst; }
        $('#total').text('Rs ' + total);
    }
}
