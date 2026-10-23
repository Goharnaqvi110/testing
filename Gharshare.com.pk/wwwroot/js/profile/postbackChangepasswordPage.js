$(document).ready(function () {
    //validation
    $('#txtOldpassword, #txtNewpassword,#txtConfirmpassword').on('input', function () {
        $('#spanOldpassword').html($('#txtOldpassword').val() === "" ? "*" : "");
        $('#spanNewpassword').html($('#txtNewpassword').val() === "" ? "*" : "");
        $('#spanConfirmpassword').html($('#txtConfirmpassword').val() === "" ? "*" : "");
    });
    $('#txtNewpassword').on('change', function () {
        //debugger;
        var password = $('#txtNewpassword').val();
        var hasUpperCase = /[A-Z]/.test(password);
        var hasLowerCase = /[a-z]/.test(password);
        if (!(hasUpperCase && hasLowerCase)) {
            swal.fire(
                {
                    icon: 'error',
                    title: 'Error',
                    text: 'Password must be at least 6 digit long and contain one capital & one small alphabet.',
                    showConfirmButton: true,
                    //timer: 2000,
                }
            );
            $('#txtNewpassword').val("");
            $('#txtNewpassword').focus();
        }
    });
    $('#txtConfirmpassword').on('change', function () {
        var Oldpassword = $('#txtOldpassword').val();
        var newPassword = $('#txtNewpassword').val();
        var confirmPassword = $('#txtConfirmpassword').val();
       // debugger;

        if (newPassword != confirmPassword) {
            swal.fire(
                {
                    icon: 'error',
                    title: 'Error',
                    text: 'Confirm password mismatch.',
                    showConfirmButton: true,
                    timer: 2000,
                }
            );
            $('#txtConfirmpassword').val("");
            $('#txtConfirmpassword').focus();
        }
    });

    //End Validation
});

function postbackChangepasswordPage() {
    debugger;
    $('#change-password-form').submit(function (event) {
        // debugger;
        var Oldpassword = $('#txtOldpassword').val();
        var newPassword = $('#txtNewpassword').val();
        var confirmPassword = $('#txtConfirmpassword').val();

        event.preventDefault(); // Prevent default form submission
        var formData = $(this).serialize(); // Serialize the form data

        if (Oldpassword != "" && newPassword != "" && confirmPassword != ""        
            && (newPassword === confirmPassword)) {
            var closeButton = $('.btn-close');
            $.ajax({
                url: '/identity/account/manage/changepassword',
                type: 'POST',
                data: formData, // Send the serialized form data
                success: function (result) {
                    if (result.success) {
                        swal.fire(
                            {
                                icon: 'success',
                                title: 'Success',
                                text: 'Password updated successfully.',
                                showConfirmButton: false,
                                timer: 2000,
                            }
                        );
                        closeButton.trigger('click');
                    }
                    else {
                        swal.fire(
                            {
                                icon: 'error',
                                title: 'Passord update failed',
                                text: result.errors,
                                showConfirmButton: true,
                                //timer: 2000,
                            }
                        );

                    }
                },
                error: function (xhr, status, error) {
                    // Handle error
                    debugger;
                    console.log(xhr);
                    swal.fire(
                        {
                            icon: 'error',
                            title: 'Error',
                            text: 'Error updating password.',
                            showConfirmButton: false,
                            timer: 2000,
                        }
                    );
                }
            });
        }
        else { //else part of validation
            if (Oldpassword === "") {
                $('#spanOldpassword').html('*');
                $('#txtOldpassword').focus();
            }
            if (newPassword === "") {
                $('#spanNewpassword').html('*');
                $('#txtOldpassword').focus();
            }
            if (confirmPassword === "") {
                $('#spanConfirmpassword').html('*');
                $('#txtConfirmpassword').focus();
            }
            if (newPassword != confirmPassword) {
                swal.fire(
                    {
                        icon: 'error',
                        title: 'Error',
                        text: 'Confirm password mismatch.',
                        showConfirmButton: true,
                        //timer: 2000,
                    }
                );
            }
        }

    });
}
