 $('body').ready(function () {
    $(document).on('change', '#totalTenants', function () {
        $('#addedrows').empty();        
        var count = $(this).val();
        for (let i = 0; i < count; i++)
        {
            var newTenant =  '<div class="row">';
            newTenant = newTenant + '<div class="col-md-4 p-1">';
            newTenant = newTenant + '<label>';
            newTenant = newTenant + (i+1)+'-Tenant Name</label > ';
            newTenant = newTenant + '<input type="text" required name="AddtionalTenants[' + i + '].FirstName"' +' asp-for="AddtionalTenants[' + i + '].FirstName"' + ' class="form-control" aria-required="true" />';
            newTenant = newTenant + '</div>';            
            newTenant = newTenant + '<div class="col-md-4 p-1">';
            newTenant = newTenant + '<label>Mobile No</label>';
            newTenant = newTenant + '<input type="text" oninput="formatMobileNumber(this)" maxlength="15" name="AddtionalTenants[' + i + '].Mobile"' +' asp-for="AddtionalTenants[' + i + '].Mobile"' + ' class="form-control" aria-required="true" />';
            newTenant = newTenant + '</div>';
            newTenant = newTenant + '<div class="col-md-4 p-1">';
            newTenant = newTenant + '<label>Email</label>';
            newTenant = newTenant + '<input type="email" onchange="checkUser(this)" oninput="clearError(this)" required name="AddtionalTenants[' + i + '].Email"' +' asp-for="AddtionalTenants[' + i + '].Email"' + ' class="form-control" aria-required="true" />';
            newTenant = newTenant + '</div>';
            newTenant = newTenant + '</div>';
            $('#addedrows').append(newTenant);
        }
    });
});
$(document).ready(function () {    
    $('#rdoRemovetenant').click(function () {
        $('#addtionaltenants').empty();
        $('.tab-content').css('height', '-=' + 400);
    });
    $('#rdotenant').click(function (e) { 
        var newTenant = '<hr />';
        newTenant = newTenant + '<div class="text-center"><strong>Addtional Tenant Details</strong></div>';
        newTenant = newTenant + '<div class="row">'; 
        newTenant = newTenant + '<div class="col-md-4 p-1">'; 
        newTenant = newTenant + '<label>No of addtional Tenants</label>'; 
        newTenant = newTenant + '<select id="totalTenants" class="nice-select btn-block">'; 
        newTenant = newTenant + '<option selected value="1">1</option>'; 
        newTenant = newTenant + '<option value="2">2</option>'; 
        newTenant = newTenant + ' <option value="3">3</option>'; 
        newTenant = newTenant + ' <option value="4">4</option>'; 
        newTenant = newTenant + '</select>';
        newTenant = newTenant + '</div>';
        newTenant = newTenant + '</div>';
        newTenant = newTenant + '<div id="addedrows">';
        newTenant = newTenant + '<div class="row">';
        newTenant = newTenant + '<div class="col-md-4 p-1">';
        newTenant = newTenant + '<label>';
        newTenant = newTenant + '1-Tenant Name</label > ';
        newTenant = newTenant + '<input type="text" required name="AddtionalTenants[0].FirstName"' + ' asp-for="AddtionalTenants[0].FirstName"' + ' class="form-control" aria-required="true" />';
        newTenant = newTenant + '</div>';
        newTenant = newTenant + '<div class="col-md-4 p-1">';
        newTenant = newTenant + '<label>Mobile No</label>';
        newTenant = newTenant + '<input type="text" oninput="formatMobileNumber(this)" maxlength="15" name="AddtionalTenants[0].Mobile"' + ' asp-for="AddtionalTenants[0].Mobile"' + ' class="form-control" aria-required="true" />';
        newTenant = newTenant + '</div>';
        newTenant = newTenant + '<div class="col-md-4 p-1">';
        newTenant = newTenant + '<label>Email</label>';
        newTenant = newTenant + '<input type="email" onchange="checkUser(this)" oninput="clearError(this)" required name="AddtionalTenants[0].Email"' + ' asp-for="AddtionalTenants[0].Email"' + ' class="form-control" aria-required="true" />';
       /* newTenant = newTenant + '<span data-valmsg-for=AddtionalTenants[0].Email data-valmsg-replace="true" class="text-danger"></span>';*/
        newTenant = newTenant + '</div>';
        newTenant = newTenant + '</div>';
        newTenant = newTenant + '</div>';
        $('#addtionaltenants').append(newTenant);         
        $('.tab-content').css('height', '+=' + 400);
    });
});