$(document).ready(function () {    
    $('#ddlsort').change(function () {
        var id = $(this).val(); 
        var searchPhrase = $('#txtsearch').val();
        var sortOrderNo = $('#ddlsort').val();
        $('#message').empty();
        $.ajax({
            url: '/search/sort?sortid=' + parseInt(id) + '&searchPhrase=' + searchPhrase + "&sortOrderNo=" + parseInt(sortOrderNo),
            success: function (data)
            {    
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
                        data.pager.sortOrderNum,data.pager.functionName, data.pager.searchPhrase, "event");
                } 
            }
        });
    });
});