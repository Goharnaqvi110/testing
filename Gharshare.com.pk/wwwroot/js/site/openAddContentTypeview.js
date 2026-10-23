
function addConentType(typeId) {
    //debugger;
    var url = null;     
    if (typeId > 0)
        url = "/admin/site/addcontentType?contentTypeId=" + typeId;
    else
        url = "/admin/site/addcontentType";

    $.ajax({
        url: url,
        type: 'GET',
        success: function (data) {
           // debugger;
            if (typeId > 0) {
                $('#basicTitle').empty().html('Edit Content Type');                 
            }
            else {
                $('#basicTitle').empty().html('Add Content Type');                
            }
            $('#basicContainer').empty().html(data);
        },
        error: function (xhr, status, error) {
            // Handle error
            //debugger;
            //console.log(xhr);
        }
    });
}
