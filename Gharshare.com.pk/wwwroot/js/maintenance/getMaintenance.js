function getMaintenance(currentpage, totalPages, fromRec, toRec, totalItems, startPage, endPage,
    pageSize, sortOrderNo, searchPhrase, event, atag) {
    let leaseId = atag.dataset.uid;
    let propertyId = atag.dataset.id;
    //debugger;
    event.preventDefault();
    //ajax call
    $.ajax({
        url: '/portal/GetMaintenanceList?currentPage=' + parseInt(currentpage) +
            "&leaseId=" + (leaseId ? encodeURIComponent(leaseId) : null) + "&propertyid=" +
            (propertyId ? encodeURIComponent(propertyId) : null) +
            "&searchText=" + (searchPhrase ? encodeURIComponent(searchPhrase) : null) +
            "&sortOrderNo=" + parseInt(sortOrderNo),
        type: 'GET',
        success: function (data) {
            //debugger;
            $('#maintenanceList').empty();
            $('#paging').empty();
            createMaintenanceList(data.maintenance);
            recreatePaging(currentpage, data.pager.totalPages, data.pager.fromRecord, data.pager.toRecord,
                data.pager.totalItems, data.pager.startPage, data.pager.endPage, data.pager.pageSize,
                data.pager.sortOrderNum, data.pager.functionName, data.pager.searchPhrase, event,
                data.pager.uid, data.pager.id);
        },
        error: function (xhr, status, error) {
            // Handle error
            debugger;
            //console.log(xhr);
        }
    });
};