function showBondPaymentUI(title, amount, dueDate,leaseId) {
    //debugger;
    var gst = Math.round(amount * 18 / 100);
    $('#divPayBond').removeClass('d-none');    
    $('#title').html(title);     
    $('#amount').html('Rs ' + Math.floor(amount));
    $('#dueDate').html(formatDateToDDMMYY(dueDate));
    $('#subTotal').html('Rs ' + Math.floor(amount));
    $('#gst').html('Rs ' + gst);

    var total = Math.round(parseInt(amount) + gst);
    $('#total').html('Rs ' + total);
    $('#leaseId').val(leaseId);

    window.scrollTo({
        top: 850,
        behavior: 'smooth' // Smooth scrolling behavior
    });
}