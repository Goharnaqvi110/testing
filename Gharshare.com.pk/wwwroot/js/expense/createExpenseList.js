function createExpenseList(expenses, leaseId) {

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
                            <th><h6>Created on</h6></th>
                            <th><h6>Status</h6></th>
                            <th class="text-center"><h6>Action</h6></th>
                        </tr>
                    </thead>
                    <tbody>`
    var sno = 1;

    for (expense of expenses) {
        html += `<tr>
                                <td>${sno}</td>
                                <td>${expense.category.title}</td>
                                <td>${expense.title}</td>
                                <td>${expense.description}</td>
                                <td>${expense.amount}</td>
                                <td>${formatDateToDDMMYY(expense.createdOn)}</td>
                                <td>
                                        <div class="d-flex align-items-center">
                                            <i class="fa fa-circle ${getClass(expense.alreadyPaid)} me-1"></i> ${getStatus(expense.alreadyPaid)}
                                        </div>
                                </td>
                                <td>
                                    <div class="text-center">
                                        <a href="#" data-bs-target="#largeModal" data-bs-toggle="modal" 
                                        onclick="loadExpense(${expense.id})" title="Edit" class="edit btn btn-danger shadow btn-xs sharp me-1">
                                            <i class="fa fa-pen"></i>Edit
                                        </a>
                                        <a href="#" data-bs-target="#largeModal" data-bs-toggle="modal" 
                                        onclick="deleteExpense(${expense.id})" title="Delete" class="edit btn btn-danger shadow btn-xs sharp me-1">
                                            <i class="fa fa-trash"></i>Delete
                                        </a>
                                        <a href="#" onclick="billTenant(${expense.id},${leaseId})" data-bs-target="#largeModal" 
                                        data-bs-toggle="modal" title="Bill tenant" class="edit btn btn-danger shadow btn-xs sharp me-1">
                                            <i class="fa fa-receipt"></i>
                                        </a>
                                    </div>
                                </td>
                            </tr>`
    }
        html +=`</tbody>
                </table>
            </div>`;
    $('#expenseList').append(html);
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