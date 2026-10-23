$(document).ready(function () {     
    $('#txtSearchAd').on('input', function () {
        //debugger;
        var searchPhrase = $(this).val();
       // debugger;
        //ajax call
        $.ajax({
            url: '/admin/property/getpropertyadlist?SearchText=' + searchPhrase,
            type: 'GET',
            success: function (data) {
               // debugger;
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
