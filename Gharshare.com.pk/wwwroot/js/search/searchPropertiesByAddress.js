function searchPropertiesByAddress(currentpage, totalPages, fromRec, toRec, totalItems, startPage, endPage,
    pageSize, sortOrderNo, searchPhrase, event) {
    //debugger;
    event.preventDefault();
    $('#message').empty();
    //ajax call
    $.ajax({
        url: '/search/searchPropertiesByAddress?currentPage=' + parseInt(currentpage) +
            "&searchPhrase=" + (searchPhrase ? encodeURIComponent(searchPhrase) : "") +
            "&sortOrderNo=" + parseInt(sortOrderNo),
        type: 'GET',
        success: function (data) {
            //debugger;
            $('#propertyList').empty();
            $('#paging').empty();
            if (data.properties.length > 0)
                createPropertyList(data.properties);
            else
                $('#message').text('no record found');

            recreatePaging(currentpage, data.pager.totalPages, data.pager.fromRecord, data.pager.toRecord,
                data.pager.totalItems, data.pager.startPage, data.pager.endPage, data.pager.pageSize,
                data.pager.sortOrderNum, data.pager.functionName, data.pager.searchPhrase, event);
        },
        error: function (xhr, status, error) {
            // Handle error
            debugger;
            //console.log(xhr);
        }
    });
    //end of ajax call

};