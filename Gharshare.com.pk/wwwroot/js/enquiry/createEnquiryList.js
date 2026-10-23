function createEnquiryList(enquiries,currentPage,pager) {

    var html = `<div class="table-responsive">
                <table class="table table-responsive-md">
                    <thead>
                        <tr>
                             <th>
                                            <h6>                                                
                                                    From                                                
                                            </h6>
                                        </th>
                                        <th>
                                            <h6>                                                 
                                                    Subject                                                 
                                            </h6>
                                        </th>
                                        <th>
                                            <h6>                                                 
                                                <a>Status</a>
                                            </h6>                                             
                                        </th>
                                        <th>
                                            <h6>
                                                <i id="dateSorting"
                                                class="${pager.sortOrderNum == 1 ? 'fa fa-arrow-up' : 'fa fa-arrow-down'}"></i>
                                                <a href="#" onclick="eval(sortEnquiries(
                                                ${currentPage},${pager.totalPages},${pager.fromRecord},${pager.toRecord},${pager.totalItems},
                                                ${pager.startPage},${pager.endPage},${pager.pageSize},${pager.sortOrderNum},${null},
                                                event,this))" data-uid="${pager.uid}" data-id="${pager.id}">Date</a>
                                            </h6>
                                        </th>
                                        <th class="text-center">
                                            <h6>Action</h6>
                                        </th>
                        </tr>
                    </thead>
                    <tbody>`
    var sno = 1;

    for (enquiry of enquiries) {
        html += `<tr>
                           <td style="width:180px;">
                                                    <img src="${enquiry.fromUser?.profilePicture ?? '../img/user-image.png'}" 
                                                    class="rounded-lg me-2" width="24" alt="">
                                                    <span class="w-space-no">${enquiry.fromUser.name}</span>
                                                </td>
                                                <td style="width:280px;">
                                                    ${enquiry.message}
                                                </td>
                                                <td>
                                                        <span class="badge ${getClass(enquiry.enquirystatus)}">
                                                            ${getStatus(enquiry.enquirystatus)}
                                                        </span>
                                                </td>
                                                <td>${formatDateToDDMMYY(enquiry.createdOn)}</td>
                                                <td class="text-center">
                                                    <a href="#" onclick="loadEnquiryinPopup(${enquiry.id})" data-bs-toggle="modal" data-bs-target="#enquiryModal">
                                                        <i class="fa fa-eye"></i> View
                                                    </a>
                                                </td>
                                 
                            </tr>`
    }
    html += `</tbody>
                </table>
            </div>`;
    $('#enquiryList').append(html);
}
function getStatus(status) {
    if (status==1)
        return "Read";
    else if (status == 2)
        return "Shortlist"
    else if (status == 3)
        return "Shortlist"
    else
        return "Not suitable"
}
function getClass(status) {
    if (status == 1)
        return "badge-success";
    else if (status == 2)
        return "badge-warning"
    else if (status == 3)
        return "Shortlist"
    else
        return "Not suitable"
}