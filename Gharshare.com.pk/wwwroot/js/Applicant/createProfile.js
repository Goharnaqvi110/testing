$(document).ready(function () {

    //debugger;
    var smartWizard = $('#smartwizard').smartWizard({
        selected: 0,
        theme: 'arrows',
        isValidationEnabled: true,
        //autoAdjustHeight: true, // Automatically adjust content height
        validatorFunc: function () {
            var isValid = $("#signUpForm").valid();
            return isValid;
        },
        toolbar: {  /// not working yet. need to figure it out.
            showNextButton: true, // show/hide a Next button
            showPreviousButton: true, // show/hide a Previous button
            position: 'both'
        },
        toolbarSettings: {
            toolbarExtraButtons: [
                $('<button>', {
                    text: 'Save',
                    class: 'btn btn-info',
                    click: function (e) {
                        // Add your custom save logic here
                        //alert('Save button clicked');
                        e.preventDefault();
                        var isValid = $('#signUpForm').valid();
                        var formId = 'signUpForm';
                        var formData = new FormData($('#' + formId)[0]);
                        if (isValid) {
                            $.ajax({
                                url: "/tenant/profile",
                                type: "POST",
                                data: formData,
                                contentType: false,
                                processData: false,
                                success: function (data) {
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
                        else {
                            swal.fire(
                                {
                                    icon: 'error',
                                    title: 'Validation error',
                                    text: 'Please fill in the form completely.',
                                    showConfirmButton: false,
                                    timer: 2000,
                                }
                            );

                        }
                    }
                })
            ]
        },
    });
    var tabOneHeightIncrease = false;
    $("#smartwizard").on("showStep", function (e, anchorObject, stepIndex, stepDirection, stepPosition) {
        // debugger;
        //// Enable or disable the Save button based on the current step
        if (stepIndex === 6 && stepDirection == 'forward') {
            $('.btn-info').prop('disabled', false);
        } else {
            $('.btn-info').prop('disabled', true);
        }
    });
    // This function will trigger validation on the 'showStep' event
    $('#smartwizard').on('leaveStep', function (e, anchorObject, stepIndex, stepDirection) {
        // debugger
        var isValid = $('#signUpForm').valid();
        if (!isValid) {
            if (stepIndex === 0 && tabOneHeightIncrease == false) {
                $('.tab-content').css('height', '+=' + 40);
                tabOneHeightIncrease = true;
            }
            e.preventDefault();
            $('#smartwizard').smartWizard('validator', stepIndex);
        }
        // debugger;
        //switch (stepIndex) {
        //    case 0:
        //        $('.progress-bar').css('width', '+=' + '12.1%');
        //    case 1:
        //        $('.progress-bar').css('width', '+=' + '24.2%');
        //    case 2:
        //        $('.progress-bar').css('width', '+=' + '36.3%');
        //    case 3:
        //        $('.progress-bar').css('width', '+=' + '48.4%');
        //    case 4:
        //        $('.progress-bar').css('width', '+=' + '60.5%');
        //    case 5:
        //        $('.progress-bar').css('width', '+=' + '72.6%');
        //    case 5:
        //        $('.progress-bar').css('width', '+=' + '27.4%');
        //}
    });
    //-------------------------------//--------------------------------------------
});
