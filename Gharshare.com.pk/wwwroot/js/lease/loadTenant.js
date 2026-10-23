$(document).ready(function () {    
    $('#ddlprimarytenant').change(function () {
        var applicantId = $(this).val();   
        if (applicantId != "" && applicantId > 0) {
            $.ajax({
                url: '/lease/LoadPrimaryTenant?applicantId=' + applicantId,
                success: function (result) {
                    $('#txtfname').val(result.firstName); 
                    $('#txtemail').val(result.email);
                    $('#txtmobile').val(result.mobile);
                }
            });
        }
        else {
            $('#txtemail').val(null);
            $('#txtmobile').val(null);
            $('#txtfname').val(null); 
        }
            
    });
    $('#txtweeklyrent').change(function () {
        var dllrentperiodval = $('#dllrentperiod').val(); //alert(dllrentperiodval);        
        let weeklyrent = $('#txtweeklyrent').val();
        if (weeklyrent > 0) {
            if (dllrentperiodval == 2) {  //Fortnightly
                let motnlyrent = (weeklyrent / 7) * 365 / 12; //alert(motnlyrent);
                let fortnightlyrent = Math.round(motnlyrent / 2); //alert(fortnightlyrent);
                $('#txtmonthlyrent').val(Math.round(motnlyrent));
                $('#txtperiodicrent').val(fortnightlyrent);
            }
            else if (dllrentperiodval == 1) { //Monthly
                let motnlyrent = (weeklyrent / 7) * 365 / 12;
                $('#txtmonthlyrent').val(Math.round(motnlyrent));
                $('#txtperiodicrent').val(Math.round(motnlyrent));
            }

        }
        else {
            Swal.fire({
                    icon: 'error',
                    title: 'Validation Error',
                    text: 'Please enter weekly rent',
                });
            //alert('Please enter weekly rent');
            $('#txtweeklyrent').focus();

        }
    });

    $('#dllrentperiod').change(function () {
        var dllrentperiodval = $(this).val(); //alert(dllrentperiodval);
        
        let weeklyrent = $('#txtweeklyrent').val();
        if (weeklyrent > 0) {
            if (dllrentperiodval == 2) //Fortnightly
            {
                let motnlyrent = (weeklyrent / 7) * 365 / 12; //alert(motnlyrent);
                let fortnightlyrent = Math.round(motnlyrent / 2); //alert(fortnightlyrent);
                $('#txtmonthlyrent').val(Math.round(motnlyrent));
                $('#txtperiodicrent').val(fortnightlyrent);
            }
            else if (dllrentperiodval == 1) //Monthly
            {
                let motnlyrent = (weeklyrent / 7) * 365 / 12;
                $('#txtmonthlyrent').val(Math.round(motnlyrent));
                $('#txtperiodicrent').val(Math.round(motnlyrent));
            }
        }
        else {
            Swal.fire({
                icon: 'error',
                title: 'Validation Error',
                text: 'Please enter weekly rent',
            });
            $('#txtweeklyrent').focus();

        }
    });
});