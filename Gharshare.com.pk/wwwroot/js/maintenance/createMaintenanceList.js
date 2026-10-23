function createMaintenanceList(maintenanceList) {

    var html = `<div class="table-responsive">
                <table class="table table-responsive-md">
                    <thead>
                        <tr>
                            <th style="width:30px;">
                            <h6>No</h6>
                        </th>
                        <th><h6>Added By</h6></th>
                        <th><h6>Category</h6></th>
                        <th><h6>Property</h6></th>
                        <th><h6>Title</h6></th>
                        <th><h6>Description</h6></th>
                        <th><h6>Amount</h6></th>
                        <th><h6>Status</h6></th>
                        <th><h6>Created on</h6></th>
                        <th class="text-center"><h6>Action</h6></th>
                        </tr>
                    </thead>
                    <tbody>`
    var sno = 1;

    for (maintenance of maintenanceList) {
        html += `<tr>
                                <td>${sno}</td>
                                <td>${maintenance.addedby == 1?"You":"Tenant"}</td>
                                <td>${maintenance.categoryTitle}</td>
                                <td>${maintenance.propertyAddress}</td>
                                <td>${maintenance.title}</td>
                                <td>${maintenance.description}</td>
                                <td>${maintenance.amount}</td>
                                <td>${formatDateToDDMMYY(maintenance.createdOn)}</td>
                                <td>
                                        <div class="d-flex align-items-center">
                                            <i class="fa fa-circle ${getClass(maintenance.status)} me-1"></i> ${getStatus(maintenance.status)}
                                        </div>
                                </td>
                                <td>
                                    <div class="text-center" style="width:60px;">
                                        <a data-bs-toggle="modal" data-bs-target="#largeModal" onclick="loadMaintenance(${maintenance.id})" title="Edit" class="edit btn btn-danger shadow btn-xs sharp me-1">
                                            <i class="fa fa-pen"></i>
                                        </a>
                                        <a data-bs-toggle="modal" data-bs-target="#largeModal" onclick="deleteMaintenance(${maintenance.id})" title="Delete" class="edit btn btn-danger shadow btn-xs sharp me-1">
                                            <i class="fa fa-trash"></i>
                                        </a>
                                    </div>
                                </td>
                            </tr>`
    }
        html +=`</tbody>
                </table>
            </div>`;
    $('#maintenanceList').append(html);
}
function getStatus(status) {
    if (status == 1)
        return "Submitted";
    else if (status == 2)
        return "Pending";
    else
        return "Completed";
}
function getClass(status) {
    if (status == 1)
        return "text-warning";
    else if (status == 2)
        return "text-danger";
    else
        return "text-success";
}