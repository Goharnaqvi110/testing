function getDocuments(currentpage, totalPages, fromRec, toRec, totalItems, startPage, endPage,
    pageSize, sortOrderNo, searchPhrase, event) {
    //debugger;
    event.preventDefault();
    //ajax call
    $.ajax({
        url: '/portal/GetDocumentList?currentPage=' + parseInt(currentpage) +
            "&searchPhrase=" + (searchPhrase ? encodeURIComponent(searchPhrase) : "") + "&sortOrderNo=" + parseInt(sortOrderNo),
        type: 'GET',
        success: function (data) {
            //debugger;
            $('#documentList').empty();
            $('#paging').empty();
            createDocumentList(data.documents);
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
};