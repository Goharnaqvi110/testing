$(document).ready(function() {
  $('#chkacknowledge').on('click', function() {
    var chkAcknowledge = $('#chkacknowledge').is(':checked');
    //console.log(chkAcknowledge);

    if (chkAcknowledge) {         
        $('.btn-info').prop('disabled', false);
    } else {
        $('.btn-info').prop('disabled', true);
    }
  });
});
