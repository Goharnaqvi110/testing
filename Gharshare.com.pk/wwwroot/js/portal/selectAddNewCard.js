function selectAddNewCard() {
    //debugger;
    $('#divNewCard').addClass('active');
    $('#divCard').removeClass('active');

    $('#spanNewCard').addClass('fa-check-circle');
    $('#spanNewCard').removeClass('fa-circle-o');

    $('#spanCard').removeClass('fa-check-circle');
    $('#spanCard').addClass('fa-circle-o');
    $('#btnUpdateCard').removeClass('disabled');
    $('.cardEntrySection').css('display', 'block');
}