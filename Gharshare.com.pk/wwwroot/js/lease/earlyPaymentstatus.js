$(document).ready(function () {
    $('#rdonoearlypayment').click(function () {
        $('#earlyPaymentRow').hide(); 
        $('.tab-content').css('height', '-=' + 100);
    });
    $('#rdoneedearlypayment').click(function (e) {
        $('#earlyPaymentRow').show();
        $('.tab-content').css('height', '+=' + 100);
    });
    $('#rdoPaymentMade').click(function () {
        $('#outsidePaymentPeriods').show();
    });
    $('#rdoPaymentNotMade').click(function () {
        $('#outsidePaymentPeriods').hide();
    });
});