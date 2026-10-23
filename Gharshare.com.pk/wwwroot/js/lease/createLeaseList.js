function createLeaseList(leaseList) {

    var html = `<div class="table-responsive">
            <table class="table table-responsive-md">
                <thead>
                    <tr>
                        <th style="width:50px;">
                            <h6>No</h6>
                        </th>
                        <th><h6>Property Address</h6></th>
                        <th><h6>Lease</h6></th>
                        <th><h6>Term</h6></th>
                        <th><h6>Lease Status</h6></th>
                        <th><h6>Type</h6></th>
                        <th class="text-center"><h6>Action</h6></th>
                    </tr>
                </thead>
                <tbody>`
               let sno = 1;
    for (let lease of leaseList) {
        html += `<tr>
                                <td>${sno}</td>
                                <td style="width:400px;">${lease.address}</td>
                                <td style="width:200px;">${lease.id}<br>${lease.tenantName}
                                <br>${lease.tenantEmail}<br>${lease.mobile}</td>                                
                                <td style="width:180px;">${formatDateToDDMMYY(lease.from)}-
                                ${formatDateToDDMMYY(lease.to)}</td>
                                <td style="width:80px;"><span class="badge light ${getClass(lease.leaseStatus)}">
                                ${getStatus(lease.leaseStatus)}</span></td>
                                <td style="width:80px;"><span class="badge light ${getTypeClass(lease.agreementType)}">
                                ${getType(lease.agreementType)}</span></td>
                                <td>
                                    <div class="text-center">
                                        <a title="View Lease" class="edit btn btn-primary shadow btn-xs sharp me-1" 
                                        href="/lease/viewleasedoc?uid=${lease.uid}">
                                            <i class="fa fa-eye"></i>
                                        </a>
                                        <a target="_blank" title="Download" class="edit btn btn-danger shadow btn-xs sharp me-1" 
                                        href="/lease/download?uid=${lease.uid}">
                                            <i class="fa fa-download"></i>
                                        </a>
                                    </div>
                                </td>
                            </tr>`
        sno += 1;
    }
    html += `</tbody>
            </table>
        </div>`;
    $('#leaseList').append(html);
}
function getStatus(status) {
    if (status == 1)
        return "Created";
    else if (status == 2)
        return "Active";
    else if (status == 3)
        return "Terminated";
    else 
        return "Renewed";
}
//Created=1, Active=2, Expired=3, Terminated=4,Renewed=5
function getClass(status) {
    if (status == 2 || status == 5)
        return "badge-success";
    else if (status == 3 || status ==4)
        return "badge-danger";
    else
        return "badge-warning";
}
function getType(type) {
    if (type == 1)
        return "Fixed";
    else
        return "Periodic";     
}
//Fixed=1,Periodic=2
function getTypeClass(agreementType) {
    if (agreementType == 1)
        return "badge-info";
    else
        return "badge-info";
}
