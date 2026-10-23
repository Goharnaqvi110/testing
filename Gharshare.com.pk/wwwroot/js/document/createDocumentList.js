function createDocumentList(documents) {

    var html = `<div class="table-responsive">
            <table class="table table-responsive-md">
                <thead>
                    <tr>
                        <th style="width:50px;">
                            <h6>No</h6>
                        </th>
                        <th><h6>Document</h6></th>
                        <th><h6>Property address</h6></th>
                        <th><h6>Created by</h6></th>
                        <th><h6>Created on</h6></th>
                        <th class="text-center"><h6>Action</h6></th>
                    </tr>
                </thead>
                <tbody>`
               let sno = 1;
    for (let document of documents) {
        html += `<tr>
                                <td>${sno}</td>
                                <td>${document.title}</td>
                                <td style="width:450px;">${document.propertyAddress}</td>
                                <td>${document.createdBy}</td>
                                <td style="width:80px;">${formatDateToDDMMYY(document.createdOn)}</td>
                                <td>
                                    <div class="text-center">
                                        <a title="View" class="edit btn btn-danger shadow btn-xs sharp me-1" href="/portal/document?uid=${document.uid}">
                                            <i class="fa fa-eye"></i>
                                        </a>
                                        <a title="Download" class="edit btn btn-danger shadow btn-xs sharp me-1" href="/portal/download?uid=${document.uid}">
                                            <i class="fa fa-download"></i>
                                        </a>
                                        <a href="#" data-bs-target="#largeModal" data-bs-toggle="modal" onclick="deleteDocument(${document.id})" title="Delete" class="edit btn btn-danger shadow btn-xs sharp me-1">
                                            <i class="fa fa-trash"></i>
                                        </a>
                                    </div>
                                </td>
                            </tr>`
        sno += 1;
    }
    html += `</tbody>
            </table>
        </div>`;
    $('#documentList').append(html);
}