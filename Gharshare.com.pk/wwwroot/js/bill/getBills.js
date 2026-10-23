function getBills(currentpage, totalPages, fromRec, toRec, totalItems, startPage, endPage,
    pageSize, sortOrderNo, searchPhrase, event, atag) {
    let uid = atag.dataset.uid;
    //debugger;
    event.preventDefault();
    //ajax call
    $.ajax({
        url: '/portal/GetBillList?currentPage=' + parseInt(currentpage) +
            "&billId=" + (uid ? encodeURIComponent(uid) : "") + "&sortOrderNo=" + parseInt(sortOrderNo),
        type: 'GET',
        success: function (data) {
            //debugger;
            $('#billList').empty();
            $('#paging').empty();
            createBillList(data.bills, data.userType);
            recreatePaging(currentpage, data.pager.totalPages, data.pager.fromRecord, data.pager.toRecord,
                data.pager.totalItems, data.pager.startPage, data.pager.endPage, data.pager.pageSize,
                data.pager.sortOrderNum, data.pager.functionName, data.pager.searchPhrase, event, uid);
        },
        error: function (xhr, status, error) {
            // Handle error
            debugger;
            //console.log(xhr);
        }
    });
};