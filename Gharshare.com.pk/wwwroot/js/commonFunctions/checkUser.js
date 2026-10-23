function checkUser(element) {
    //debugger;
    var userName = $(element).val().trim();
    if (userName != null && userName != "") {
        var $nextSpan = $(element).next('span');
        if (!$nextSpan.length) {
            $nextSpan = $('<span class="text-danger"></span>');
            $(element).after($nextSpan);
        }
        // Ajax call to check user name 
        $.ajax({
            url: '/home/checkUsername?userName=' + userName,
            success: function (result) {
                if (result) {
                    //debugger;
                    $(element).val('');
                    $(element).focus();
                    $(element).next('span').html('&nbsp;User name already taken &nbsp;');
                }
            }
        });
        // Ajax call to validate demo request Ends
    }
}

// clear 'spanEmail' on input event of

function clearError(element) {
    $(element).next('span').html('');
}
