$(document).ready(function () {
    $('#ddllandlords').on('change', function () {
        //debugger;
        var landlordId = $(this).val().trim();        
        //ajax call
        $.ajax({
            url: '/admin/property/getpropertyadlist?landlordId=' + landlordId,
            type: 'GET',
            success: function (data) {
                //debugger;                 
                createPropertyAdList(data);
            },
            error: function (xhr, status, error) {
                // Handle error
                //debugger;
                //console.log(xhr);
            }
        });
        //end of ajax call
    });
});
