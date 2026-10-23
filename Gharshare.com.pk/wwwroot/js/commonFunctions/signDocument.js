$(document).ready(function () {
    let increaseheight=true;
    var signature;
    $('#exampleModal').one('shown.bs.modal', function (e) {
        signature = $("#signature").jSignature({ 'UndoButton': true });
        document.getElementsByTagName('canvas')[0].setAttribute('width', '400');
    });

    $('#preview').click(function () {
        var data = signature.jSignature('getData', 'image');
        $('#signaturePreview').attr('src', "data:" + data);
        $('#sigval').val(data[1]); // signature data
        var currentDate = moment().format('DD-MM-YYYY HH:mm:ss');
        var isModified = signature.jSignature('isModified');
        if (isModified) {
            $("#signedon").text(currentDate);
            $('#sigDate').val(currentDate);
            $('#lblsignon').css('display', 'block');
            $('#btnclick2sign').css('display', 'none'); 
            $('#btnSave').css('display', 'block');
            if (increaseheight) {
                $('.card').css('height', '+=' + 130);
                increaseheight = false;
            }
        }
        else {
            $("#signedon").text("");
            $('#sigDate').val();
            $('#lblsignon').css('display', 'none');
            $('#btnclick2sign').css('display', 'block');
            $('#btnSave').css('display', 'none');
            $('.card').css('height', '-=' + 130);
        }
    });     
});