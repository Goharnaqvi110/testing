
function deleteAccepting(Id) {
    //debugger;
    var url = null;
    url = "/admin/site/deleteaccepting?acceptingId=" + Id;
    $.ajax({
        url: url,
        type: 'GET',
        success: function (data) {
            // debugger;            
            $('#basicTitle').empty().html('Delete Accepting');            
            $('#basicContainer').empty().html(data);
        },
        error: function (xhr, status, error) {
            // Handle error
            //debugger;
            //console.log(xhr);
        }
    });
}
