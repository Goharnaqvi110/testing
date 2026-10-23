function selectDefaultBank() {     
    $('#divNewBank').removeClass('active');
    $('#divBank').addClass('active');

    $('#spanNewBank').removeClass('fa-check-circle');
    $('#spanNewBank').addClass('fa-circle-o');

    $('#spanBank').addClass('fa-check-circle');
    $('#spanBank').removeClass('fa-circle-o');
    $('#btnUpdateBankAccount').addClass('disabled');
    $('.bankAccountEntrySection').css('display', 'none');
}
function deSelectDefaultBank() {
    $('.bankAccountEntrySection').css('display', 'block');
    $('#btnUpdateBankAccount').removeClass('disabled');

    $('#divNewBank').addClass('active');
    $('#divBank').removeClass('active');

    $('#spanNewBank').addClass('fa-check-circle');
    $('#spanNewBank').removeClass('fa-circle-o');

    $('#spanBank').removeClass('fa-check-circle');
    $('#spanBank').addClass('fa-circle-o');
    
}