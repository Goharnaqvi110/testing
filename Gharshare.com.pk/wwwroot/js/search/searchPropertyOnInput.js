$(document).ready(function () {
    $('#txtsearch').on('input', function () {
        var searchPhrase = $(this).val();
        $('#txtsearch').val(searchPhrase);
        var sortOrderNo = $('#ddlsort').val();
        $('#message').empty();
        //debugger;
        $.ajax({
            url: '/search/searchonInput?searchPhrase=' + searchPhrase + "&sortOrderNo=" + parseInt(sortOrderNo),
            success: function (data) {
                //debugger;
                $('#propertyList').empty();
                $('#paging').empty();
                if (data.properties.length > 0)
                    createPropertyList(data.properties);
                else
                    $('#message').text('no record found');
                if (data.pager.totalPages > 1) {
                    recreatePaging(data.pager.currentPage, data.pager.totalPages, data.pager.fromRecord, data.pager.toRecord,
                        data.pager.totalItems, data.pager.startPage, data.pager.endPage, data.pager.pageSize,
                        data.pager.sortOrderNum, data.pager.functionName, data.pager.searchPhrase, "event");
                }
            }
        });
    });
});