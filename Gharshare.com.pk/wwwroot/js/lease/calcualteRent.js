$(document).ready(function () {
    debugger;
    $('#txtMonthlyRent').change(function () {
        let monthlyRent = $('#txtMonthlyRent').val();
        $('#txtPeriodicRent').val(Math.round(monthlyRent));
    });
    $('#txtweeklyrent').change(function () {
        //debugger;
        var dllrentperiodval = $('#dllrentperiod').val(); //alert(dllrentperiodval);        
        let weeklyrent = $('#txtweeklyrent').val();
        if (weeklyrent > 0) {
            if (dllrentperiodval == "Fortnightly") {  //Fortnightly
                let motnlyrent = (weeklyrent / 7) * 365 / 12; //alert(motnlyrent);
                let fortnightlyrent = Math.round(motnlyrent / 2); //alert(fortnightlyrent);
                $('#txtmonthlyrent').val(Math.round(motnlyrent));
                $('#txtperiodicrent').val(fortnightlyrent);
            }
            else if (dllrentperiodval == "Monthly") { //Monthly
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
        debugger;
        var dllrentperiodval = $(this).val(); //alert(dllrentperiodval);
        
        let weeklyrent = $('#txtweeklyrent').val();
        if (weeklyrent > 0) {
            if (dllrentperiodval =="Fortnightly") //Fortnightly
            {
                let motnlyrent = (weeklyrent / 7) * 365 / 12; //alert(motnlyrent);
                let fortnightlyrent = Math.round(motnlyrent / 2); //alert(fortnightlyrent);
                $('#txtmonthlyrent').val(Math.round(motnlyrent));
                $('#txtperiodicrent').val(fortnightlyrent);
            }
            else if (dllrentperiodval == "Monthly") //Monthly
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