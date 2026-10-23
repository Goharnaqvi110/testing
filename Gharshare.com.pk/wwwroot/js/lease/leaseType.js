$(document).ready(function () {
    $('#ddlleasetype').change(function () {
        var id = $(this).val();        
        var leaseType = $(this).val();
        if (leaseType == 'Periodic')
        {
            //$('#divto').empty();
            $('#dtpto').prop("disabled", true);
        }            
        else if (leaseType == 'FixedTerm')
        {
            $('#dtpto').prop("disabled", false);
            /*var toDate = '<div id="divto" class="col-md-4 form-group p-1">';*/
            //var toDate ='<label asp-for="@Model.leaseAgreement.To" class="control-label">End Date</label>';
            //toDate = toDate + '<input type="date" asp-for="@Model.leaseAgreement.To" class="form-control" />';
            //toDate = toDate + '<span asp-validation-for="@Model.leaseAgreement.To" class="text-danger"></span>';
            //toDate = toDate + '</div>';            
            //$('#divto').append(toDate);
            //$('#newdivto').css({ "width": "100%" });
        }
    });

});