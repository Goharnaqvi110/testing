
function deleteFeature(Id) {
    //debugger;
    var url = null;
    url = "/admin/site/deletefeature?featureId=" + Id;
    $.ajax({
        url: url,
        type: 'GET',
        success: function (data) {
            // debugger;            
            $('#basicTitle').empty().html('Delete Feature');            
            $('#basicContainer').empty().html(data);
        },
        error: function (xhr, status, error) {
            // Handle error
            //debugger;
            //console.log(xhr);
        }
    });
}
