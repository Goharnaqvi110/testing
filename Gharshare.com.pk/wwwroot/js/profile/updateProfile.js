$(document).ready(function () {

    //Validation
    $('#txtName,#txtEmail').on('input', function () {
        $('#spanName').html($('#txtName').val() === "" ? "*" : "");
        $('#spanEmail').html($('#txtEmail').val() === "" ? "*" : "");
       // $('#spanMobile').html($('#txtMobile').val() === "" ? "*" : "");

        // Email validation
        const emailInput = $('#txtEmail')[0];
        //debugger;
        if (emailInput.validity.typeMismatch || emailInput.value === "") {
            $('spanEmail').html("*");
            //$('#spanEmailMsg').html("* Invalid email address");
        } else {
            $('#spanEmail').html("");
            //$('#spanEmailMsg').html("");
        }
    });

    //End Validation

    $('#accountSettingsForm').submit(function (event) {
        event.preventDefault(); // Prevent default form submission
        var formId = 'accountSettingsForm';
        var formData = new FormData($('#' + formId)[0]);
         
        var closeButton = $('.btn-close');
       // debugger;
        var name = $('#txtName').val();
        var email = $('#txtEmail').val();

        // Perform AJAX form submission
        if (name != "" && email != "") {
            $.ajax({
                url: "/profile/accountsettings",
                type: "POST",
                data: formData,
                contentType: false,
                processData: false,
                success: function (data) {                     
                    var name = data.name.split(' ')[0];
                   // $('#spanLoginName').append(name);
                     
                    swal.fire(
                        {
                            icon: 'success',
                            title: 'Success',
                            text: 'Account updated successfully.',
                            showConfirmButton: false,
                            timer: 2000,
                        }
                    );
                    closeButton.trigger('click');
                },
                error: function (xhr, status, error) {

                    // Handle the error response
                    // For example, display an error message or handle the error case
                    swal.fire(
                        {
                            icon: 'error',
                            title: 'Error',
                            text: 'Error updating profile.',
                            showConfirmButton: false,
                            timer: 2000,
                        }
                    );
                }
            });
        }
        else {   /// validation else block
            if (name === "") {
                document.getElementById('spanName').innerHTML = "*";
                document.getElementById('txtName').focus();
            }
            if (email === "") {
                document.getElementById('spanEmail').innerHTML = "*";
                document.getElementById('txtEmail').focus();
            }

        }
    });
});
