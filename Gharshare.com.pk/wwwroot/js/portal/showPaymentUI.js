function showPaymentUI(cat, title, desc, amount, dueDate,billId) {
    //debugger;
    var gst = Math.round(amount * 18 / 100);
    $('#divPaybill').removeClass('d-none');
    $('#cat').html(cat);
    $('#title').html(title);
    $('#desc').html(desc);
    $('#amount').html('Rs ' + Math.floor(amount));
    $('#dueDate').html(dueDate);
    $('#subTotal').html('Rs ' + Math.floor(amount));
    $('#gst').html('Rs ' + gst);

    var total = Math.round(parseInt(amount) + gst);
    $('#total').html('Rs ' + total);

    $('#billId').val(billId);
    window.scrollTo({
        top: document.body.scrollHeight,
        behavior: 'smooth' // Smooth scrolling behavior
    });
}