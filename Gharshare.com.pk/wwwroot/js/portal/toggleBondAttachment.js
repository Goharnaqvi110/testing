function toggleBondAttachment() {
    //debugger;
    var toggleVal = $('#toggle').val();
    if ($('#toggle').val()==0) {
        $('#attachments').removeClass('d-none');
        $('#toggle').val(1); 
        $('#attachment-toggle').html('See less <i class="fa fa-minus"></i>');
    }
    else {
        $('#toggle').val(0);
        $('#attachments').addClass('d-none');        
        $('#attachment-toggle').html('See More <i class="fa fa-plus"></i>');
    }

}