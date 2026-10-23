
function addFeature(Id) {
   //debugger;
    var url = null;     
    if (Id > 0)
        url = "/admin/site/addfeature?Id=" + Id;
    else
        url = "/admin/site/addfeature";

    $.ajax({
        url: url,
        type: 'GET',
        success: function (data) {
           // debugger;
            if (Id > 0) {
                $('#basicTitle').empty().html('Edit Feature');                 
            }
            else {
                $('#basicTitle').empty().html('Add Feature');                
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
