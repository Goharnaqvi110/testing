$(document).ready(function () {

    $("#frmreport").validate({
        rules: {
            'Property.AvailableFrom': {
                required: true
            },
            'Property.BondValue': { required: true },
            'Property.Parkingtype': { required: true },
            'Property.BondValue': {
                required: true,
                number: true,
            },
            'Property.Rent': {
                required: true,
                number: true,
            },
            'Property.CatogryID': {
                required: true
            },
            'Property.AdTitle': {
                required: true
            },

            'Property.Description': {
                required: true
            },
            'Property.Owner.Name': {
                required: true
            },
            'Property.Owner.Email': {
                required: true,
                email:true
            },
            'Property.Owner.PhoneNumber': {
        required: true
    },
            'Property.Street': { required: true },
            files: { required: true },
            CityID: { required: true },
            Address: { required: true },
        },
        messages: {
            'Property.AvailableFrom': {
                required: "<span class='text-danger'><strong>*<strong></span>"
            },
            'Property.BondValue': {
                required: "<span class='text-danger'><strong>*<strong></span>",
                number: "<span class='text-danger'>&nbspPlease enter a valid number</span>"
                //pattern: "<span class='text-danger'><strong>Enter a valid number<strong></span>"
            },
            'Property.Rent': {
                required: "<span class='text-danger'><strong>*<strong></span>",
                number: "<span class='text-danger'>&nbspPlease enter a valid number</span>"
            },
            'Property.CatogryID': {
                required: "<span class='text-danger'><strong>*<strong></span>"
            },
            'Property.AdTitle': {
                required: "<span class='text-danger'><strong>*<strong></span>"
            },
            'Property.Description': {
                required: "<span class='text-danger'><strong>*<strong></span>"
            },
            'Property.Parkingtype': {
                required: "<span class='text-danger'><strong>*<strong></span>"
            },
            'Property.Street': {
                required: "<span class='text-danger'><strong>*<strong></span>"
            },
            files: { required: "<span class='text-danger'>*</span>", },
            CityID: { required: "<span class='text-danger'>*</span>", },
            Address: { required: "<span class='text-danger'>*</span>", },

            'Property.Owner.Name': { required: "<span class='text-danger'>*</span>", },
            'Property.Owner.Email': {
                required: "<span class='text-danger'>*</span>",
                email: "<span class='text-danger'>&nbspPlease enter a valid email</span>"
                },
            'Property.Owner.PhoneNumber': { required: "<span class='text-danger'>*</span>", },

        }
    });

    var smartWizard = $('#smartwizard').smartWizard({
        selected: 0,
        theme: 'arrows',
        isValidationEnabled: true,
        validatorFunc: function () {
            var isValid = $("#frmreport").valid();
            return isValid;
        },
        toolbarSettings: {
            toolbarExtraButtons: [
                $('<button>', {
                    text: 'Save',
                    class: 'btn btn-info',
                    //disabled: 'true',
                    click: function (e) {
                        // alert('Save button clicked');
                        e.preventDefault();
                        var isValid = $('#frmreport').valid();
                        var formId = 'frmreport';
                        var formData = new FormData($('#' + formId)[0]);
                        if (isValid) {
                            $("#stepalert").show();
                            $.ajax({
                                url: "/conditionreport/savereport",
                                type: "POST",
                                data: formData,
                                contentType: false,
                                processData: false,
                                success: function (creport) {
                                    //debugger;
                                    $("#stepalert").hide();
                                    // Update the href attribute with the idValue
                                    $('#reportId').val(creport.id);
                                    $('#embedreport').prop('src', creport.filePath);
                                    //var url = '/conditionreport/viewconditionreport/' + data;
                                    // Set the href attribute with the constructed URL
                                    //$('#viewReport').attr('href', url);
                                    // Move to step 2 of the jQuery Smart Wizard
                                    $('#smartwizard').smartWizard("goToStep", 1);                                     
                                    $('.btn-info').prop('disabled', true);
                                    swal.fire(
                                        {
                                            icon: 'success',
                                            title: 'Success',
                                            text: 'Condition report created successfully.',
                                            showConfirmButton: false,
                                            timer: 2000,
                                        }
                                    );
                                },
                                error: function (xhr, status, error) {
                                    debugger;
                                    // Handle the error response                                     
                                    swal.fire(
                                        {
                                            icon: 'error',
                                            title: 'Error',
                                            text: xhr.responseText,
                                            showConfirmButton: false,
                                            timer: 2000,
                                        }
                                    );
                                }
                            });
                        }
                        else {
                            Swal.fire({
                                icon: 'error',
                                title: 'Validation error',
                                text: 'Please fill in the form completely.',
                                showConfirmButton: false,
                                timer: 2000,
                            }).then(function () {
                                $('html, body').animate({
                                    scrollTop: 0 // Scroll to the top of the page
                                }, 500);
                            });
                        }
                    }
                })
            ]
        },
    });

    // This function will trigger validation on the 'showStep' event
    $('#smartwizard').on('leaveStep', function (e, anchorObject, stepIndex, stepDirection) {
        console.log(stepIndex);
        var isValid = $('#frmreport').valid();
        if (!isValid) {
            e.preventDefault();
            $('#smartwizard').smartWizard('validator', stepIndex);
        }
    });
});
    //-------------------------------//--------------------------------------------

