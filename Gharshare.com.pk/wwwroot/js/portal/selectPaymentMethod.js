function selectPaymentMethod(selectedOption, id)
{
    //debugger;
    $('.paymentMethodCard').removeClass('active')
    $(selectedOption).addClass('active');
    $('.option').removeClass('fa-check-circle');
    $('.option').addClass('fa-circle-o');
    $(selectedOption).find('.option').addClass('fa-check-circle');
    $(selectedOption).find('.option').removeClass('fa-circle-o');
    //debugger;
    var selectedValue = $('#selected').val();
    if (selectedValue == id)
        $('#btnUpdate').addClass('disabled');
    else
    {
        $('#btnUpdate').removeClass('disabled');
        $('#selectedPaymentOption').val(id);
    }
}