$(document).ready(function () {

    $("#frmLease").validate({
        rules: {
            email: {
                required: true,
                email: true
            },
            CityID: { required: true },
            Ownermobile: { required: true },
            Address: { required: true },
            Propertytype: { required: true, },
            CatogryID: { required: true, },
            "PrimaryTenant.FirstName":{ required: true, },
        },
        messages: {
            email: {
                required: "<span class='text-danger'>*</span>",
                email: "Please enter a valid email address"
            },
            CityID: { required: "<span class='text-danger'>*</span>", },
            Address: { required: "<span class='text-danger'>*</span>", },            
            Ownermobile: { required: "<span class='text-danger'>*</span>", },
            CatogryID: { required: "<span class='text-danger'>*</span>", },
            Propertytype: { required: "Please select property type" },
            FirstName: { required: "<span class='text-danger'>*</span>", },
        //    phone: {
        //        required: "Please enter your phone number",
        //        phoneUS: "Please enter a valid US phone number"
        //    }
        }
    });

    var smartWizard = $('#smartwizard').smartWizard({
        selected: 0,
        theme: 'arrows',
        isValidationEnabled: true,
        validatorFunc: function () {
            var isValid = $("#frmLease").valid();
            return isValid;
        },
        toolbarSettings: {
            toolbarExtraButtons: [
                $('<button>', {
                    text: 'Save',
                    class: 'btn btn-info',
                    disabled: 'true', //for debugging, set to false
                    click: function (e) {                         
                       // alert('Save button clicked');
                        e.preventDefault();
                        var isValid = $('#frmLease').valid(); //true;commented to debug, uncomment later.
                        var formId = 'frmLease';
                        var formData = new FormData($('#' + formId)[0]);                        
                        if (isValid) {
                            $("#stepalert").removeClass('d-none');
                            $('.btn-info').addClass('disabled');
                            $.ajax({
                                url: "/lease/createlease",
                                type: "POST",
                                data: formData,
                                contentType: false,
                                processData: false,
                                success: function (data) {
                                    $("#stepalert").addClass('d-none');
                                    $('.btn-info').removeClass('disabled');
                                    //debugger;
                                    //$('.btn-info').prop('disabled', true);                                    
                                    swal.fire(
                                        {
                                            icon: 'success',
                                            title: 'Success',
                                            text: 'Lease created successfully.',
                                            showConfirmButton: false,
                                            timer: 2000,
                                        }
                                    ); 
                                    window.location.href = "/lease/send/" + data;
                                },
                                error: function (xhr, status, error) {
                                    $("#stepalert").addClass('d-none');
                                    $('.btn-info').removeClass('disabled');                                    
                                    swal.fire(
                                        {
                                            icon: 'error',
                                            title: 'Error',
                                            text: xhr.responseText,
                                            showConfirmButton: true,
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
        if (stepIndex === 7 && stepDirection == 'forward') {
            $('.btn-info').prop('disabled', false);
        } else {
            $('.btn-info').prop('disabled', true);
        }
    });
    // This function will trigger validation on the 'leaveStep' event
    $('#smartwizard').on('leaveStep', function (e, anchorObject, stepIndex, stepDirection) {
         
        //console.log(stepIndex);
        var isValid = $('#frmLease').valid();
        if (!isValid) {
            e.preventDefault();
            $('#smartwizard').smartWizard('validator', stepIndex);
        }

        ///Step-1 Validation
        if (stepIndex === 0) { 
        //var selectedRadio = $('#step-1 input[name="Propertytype"]:checked');
        //if (selectedRadio.length === 0) {
        //    e.preventDefault();
        //    $('#step-1').find('.sw-btn-next').prop('disabled', true); // disable next button
        //    //alert('select property type');
        //    Swal.fire({
        //        icon: 'error',
        //        title: 'Validation Error',
        //        text: 'Must select one option from property type',
        //        //footer: '<a href="">Why do I have this issue?</a>'
        //    });
        //}
        } //////Step-1 Validation Ends
        //------------------
        else if(stepIndex === 1)   // Validation check for step-2
        {
            //var selectedtenantopt = $('#step-2 input[name="PlanId"]:checked');
            //if (selectedtenantopt.length === 0) {
            //    e.preventDefault();
            //    $('#step-2').find('.sw-btn-next').prop('disabled', true); // disable next button             
            //    Swal.fire({
            //        icon: 'error',
            //        title: 'Validation Error',
            //        text: 'Must select one option from tenant status',
            //    });
            //}
        }
         /// Validation for step-2 ends
    });
    //-------------------------------//--------------------------------------------

    //Move to step-2 as user selects option on step-1
    var radioButtons = $('#step-1 input[name="Property.HideAddress"]');

    // Add an event listener to the radio buttons
    radioButtons.on('click', function () {
        // Get the selected radio button value
        var selectedValue = $(this).val();

        // Move to the next step using the smartWizard API
        $('#smartwizard').smartWizard('next');
    });
    ////-----------------///--------------------------
     
});
