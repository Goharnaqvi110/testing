$(document).ready(function () {
    $('#txtEmail').on('change', function () {
        var emailAddress = $('#txtEmail').val().trim();
        if (emailAddress != null && emailAddress !="") {
            // Ajax call to validate demo request starts
            $.ajax({
                url: '/about/checkReferralStatus?emailAddress=' + emailAddress,
                success: function (result) {
                    if (result) {
                       // debugger;
                        $('#txtEmail').val('');                        
                        $('#spanEmail').html('&nbsp;You have already referred smartpropertymanager.pk to this friend !');                         
                    }
                }
            });
            // Ajax call to check if the friend has already been referred to SPM
        }
    });

    // clear 'spanEmail' on input event of

    $('#txtEmail').on('input', function () {

        $('#spanEmail').html('');
    });

});
