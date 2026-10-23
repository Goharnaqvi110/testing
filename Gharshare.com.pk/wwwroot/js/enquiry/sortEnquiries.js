function sortEnquiries(currentpage, totalPages, fromRec, toRec, totalItems, startPage, endPage,
    pageSize, sortOrderNo, searchPhrase, event, atag) {
    let uid = atag.dataset.uid;
    let type = atag.dataset.id;
    //debugger;
    event.preventDefault();
    //ajax call
    $.ajax({
        url: '/enquiry/SortEnquiryList?currentPage=' + parseInt(currentpage) + "&type=" + type +
            "&porpertyUid=" + (uid ? encodeURIComponent(uid) : "") + "&searchText=" + searchPhrase +
            "&sortOrderNo=" + parseInt(sortOrderNo),
        type: 'GET',
        success: function (data) {
            //debugger;
            $('#enquiryList').empty();
            $('#paging').empty();
            createEnquiryList(data.enquiries, currentpage, data.pager);
            recreatePaging(currentpage, data.pager.totalPages, data.pager.fromRecord, data.pager.toRecord,
                data.pager.totalItems, data.pager.startPage, data.pager.endPage, data.pager.pageSize,
                data.pager.sortOrderNum, data.pager.functionName, data.pager.searchPhrase, event,uid, type);
        },
        error: function (xhr, status, error) {
            // Handle error
            debugger;
            //console.log(xhr);
        }
    });
};