
function deletecontentytype(contentTypeId) {

    $.ajax({
        url: "/admin/site/deletecontentytype?contentTypeId=" + contentTypeId,
        type: 'GET',
        success: function (data) {
            // debugger;
            $('#basicTitle').empty().html('Delete content type');
            $('#basicContainer').empty().html(data);
        },
        error: function (xhr, status, error) {
            // Handle error
            //debugger;
            //console.log(xhr);
        }
    });
}
