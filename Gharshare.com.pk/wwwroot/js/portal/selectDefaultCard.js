function selectDefaultCard() {
    //debugger;
    $('#divNewCard').removeClass('active');
    $('#divCard').addClass('active');

    $('#spanNewCard').removeClass('fa-check-circle');
    $('#spanNewCard').addClass('fa-circle-o');

    $('#spanCard').addClass('fa-check-circle');
    $('#spanCard').removeClass('fa-circle-o');
    $('#btnUpdateCard').addClass('disabled');
    $('.cardEntrySection').css('display', 'none');
}