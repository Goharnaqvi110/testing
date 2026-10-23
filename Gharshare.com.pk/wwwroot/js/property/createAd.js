$(document).ready(function () {

    $("#createAdd").validate({
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
            var isValid = $("#createAdd").valid();
            return isValid;
        },
        toolbarSettings: {
            toolbarExtraButtons: [
                $('<button>', {
                    text: 'Save',
                    class: 'btn btn-info',
                    disabled: 'true',
                    click: function (e) {
                        // alert('Save button clicked');
                        e.preventDefault();
                        var isValid = $('#createAdd').valid();
                        var formId = 'createAdd';
                        var formData = new FormData($('#' + formId)[0]);
                        if (isValid) {
                            $.ajax({
                                url: "/property/createad",
                                type: "POST",
                                data: formData,
                                contentType: false,
                                processData: false,
                                success: function (uid) {
                                    debugger;
                                    $('.btn-info').prop('disabled', true); 
                                    swal.fire({
                                        title: "Confirmation",
                                        text: 'Your ad has been successfully saved. One more step. You will need to pay in order for your ad to go live. Simply click "Pay Now" on the property card on the banner in My Properties or click below "Pay Now" button.',
                                        showDenyButton: true,
                                        showCancelButton: false,
                                        confirmButtonText: "Back to My Properties",
                                        confirmButtonColor: "#082642",
                                        denyButtonText: `Pay Now`,
                                        denyButtonColor: "#FF005D",
                                    }).then((result) => {
                                        /* Read more about isConfirmed, isDenied below */
                                        if (result.isConfirmed) {
                                            window.location.href = "/property/list";                                    
                                        } else if (result.isDenied) {
                                            window.location.href = "/portal/checkout?uid=" + uid;                                    
                                        }
                                    });
                                    //swal.fire(
                                    //    {
                                    //        icon: 'success',
                                    //        title: 'Success',
                                    //        text: 'Ad created successfully.',
                                    //        showConfirmButton: false,
                                    //        timer: 2000,
                                    //    }
                                    //);
                                    //window.location.href = "/property/list";                                    
                                },
                                error: function (xhr, status, error) {

                                    // Handle the error response
                                    // For example, display an error message or handle the error case
                                    swal.fire(
                                        {
                                            icon: 'error',
                                            title: 'Error',
                                            text: 'Error creating property advertisement.',
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
    $("#smartwizard").on("showStep", function (e, anchorObject, stepIndex, stepDirection, stepPosition) {
        // debugger;
        //// Enable or disable the Save button based on the current step
        var chkAcknowledge = $('#chkacknowledge').is(':checked');
        //console.log(chkAcknowledge);
        if (stepIndex === 5 && stepDirection == 'forward' && chkAcknowledge===true) {
            $('.btn-info').prop('disabled', false);
        } else {
            $('.btn-info').prop('disabled', true);
        }
    });
    // This function will trigger validation on the 'leaveStep' event
    $('#smartwizard').on('leaveStep', function (e, anchorObject, stepIndex, stepDirection) {
        console.log(stepIndex);
        var isValid = $('#createAdd').valid();
        if (!isValid) {
            e.preventDefault();
            $('#smartwizard').smartWizard('validator', stepIndex);
        }
        /*Step-5 Validation*/
        if (stepIndex === 4) {
            if ($('#images').is(':empty')) {                
                Swal.fire({
                    icon: 'error',
                    icon: 'error',
                    title: 'Validation Error',
                    text: 'Please save images before moving to the next step',
                });
                e.preventDefault();
            }
        }
    });
});
    //-------------------------------//--------------------------------------------

