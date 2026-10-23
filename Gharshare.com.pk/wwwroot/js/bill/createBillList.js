function createBillList(bills, userType) {

    var html = `<div class="table-responsive">
                <table class="table table-responsive-md">
                    <thead>
                        <tr>
                             <th style="width:50px;">
                            <h6>No</h6>
                        </th>
                        <th><h6>Category</h6></th>
                        <th><h6>Title</h6></th>
                        <th><h6>Description</h6></th>
                        <th><h6>Amount</h6></th>
                        <th><h6>Due date</h6></th>
                        <th><h6>Attachment(s)</h6></th>
                        <th><h6>Created on</h6></th>
                        <th><h6>Status</h6></th>
                        <th class="text-center"><h6>Action</h6></th>
                        </tr>
                    </thead>
                    <tbody>`
    var sno = 1;

    for (bill of bills) {
        html += `<tr>
                                <td>${sno}</td>
                                <td>${bill.category.title}</td>
                                <td>${bill.title}</td>
                                <td>${bill.description}</td>
                                <td>${bill.amount}</td>
                                <td>${formatDateToDDMMYY(bill.dueDate)}</td><td>`
        var docNo = 1;
        for (billDoc of bill.billDocuments) {
            if (billDoc.filePath != null) {
                html += `<a href="${window.location.origin}${billDoc.filePath}">Attachement-${docNo}</a>
                                            <br>`
            }
            else {
                html += `NA`;
            }
            sno += 1;
        }
        if (bill.billDocuments.length == 0)
            html += `NA`;
        html += `</td><td>${formatDateToDDMMYY(bill.createdOn)}</td>
                                <td>
                                        <div class="d-flex align-items-center">
                                            <i class="fa fa-circle ${getClass(bill.isPaidByTenant)} me-1"></i> ${getStatus(bill.isPaidByTenant)}
                                        </div>
                                </td>
                                <td>`
        if (userType == "landlord") {
            html += `<div class="text-center" style="width:80px;">
                <a href="#" data-bs-target="#largeModal" data-bs-toggle="modal" onclick="editBill(${bill.id})" title="Edit bill" class="edit btn btn-danger shadow btn-xs sharp me-1">
                    <i class="fa fa-pen"></i>
                </a>
                <a href="#" data-bs-target="#largeModal" data-bs-toggle="modal" onclick="deleteBill(${bill.id})" title="Delete bill" class="edit btn btn-danger shadow btn-xs sharp me-1">
                    <i class="fa fa-trash"></i>
                </a>
            </div>`
        }
        else if (userType == "tenant" && !(bill.isPaidByTenant) ) {
            html += `<a href="#" onclick="showPaymentUI('${bill.category.title}',
'${bill.title}',
'${bill.description}',
'${bill.amount}',
'${formatDateToDDMMYY(bill.dueDate)}',${bill.id})" id="proceed2pay" class="red-link">
                                            <i class="fa fa-credit-card"></i>
                                            Proceed to payment
                                        </a>`
        }
        html += `</td></tr>`
    }
    html += `</tbody>
                </table>
            </div>`;
    $('#billList').append(html);
}
function getStatus(isPaid) {
    if (isPaid)
        return "Paid";
    else
        return "Unpaid"
}
function getClass(isPaid) {
    if (isPaid)
        return "text-success";
    else
        return "text-danger"
}