function scrollToBottom(button,event, planName, monthlyCharges, upFrontCharges) {
    //debugger;
    event.preventDefault(); // Prevent default link behavior (jumping to the top of the page)
    // Scroll down to the bottom of the page
    window.scrollTo({
        top: document.body.scrollHeight,
        behavior: 'smooth' // Smooth scrolling behavior
    });
    $('.card').css('border', 'none');
    $(button).closest('.card').css('border', '1px solid red');

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
//document.querySelectorAll('.selectPlan').forEach(function (link) {
//    link.addEventListener('click', scrollToBottom);
//});
