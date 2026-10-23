function createPropertyAdList(data) {
    var userListDiv = document.getElementById("list");
    userListDiv.innerHTML = ''; // Clear existing content     
    if (data.length > 0) {
        $('#response').empty();
        var tableHTML = `
        <table class="table table-responsive-md">
            <thead>
                <tr>
                    <th style="width: 50px;"><strong>No</strong></th>
                    <th><strong><i></i>
                    <a href="/admin/property/index?pg=1&amp;sortOrder=address">
                     Property
                    </a></strong></th>
                    <th><strong> 
                    <i class="fa fa-arrow-down"></i>
                    <a href="/admin/property/index?pg=1&amp;sortOrder=name">
                     Landlord
                    </a></strong></th>
                    <th><strong>Ad Created On</strong></th>
                    <th><strong>Status</strong></th>
                    <th class="text-center"><strong>Action</strong></th>
                </tr>
            </thead>
            <tbody>
    `;

        for (var i = 0; i < data.length; i++) {
            var property = data[i];
            var statusIconClass = getStatusClass(property.blockedbyAdmin);
            var statusText = getStatusText(property.blockedbyAdmin);

            var status = property.blockedbyAdmin === true ? 'Unblocked' : 'blocked';

            tableHTML += `
            <tr>
                <td>${i + 1}</td>
                <td>
                <div>
             <span class="w-space-no">${property.address}</span>
             </div>  
                </td>
                <td>${property.owner.name}</td>
                <td>${formatDateToDDMMYY(property.createdOn)}</td>
                <td>
                    <div class="d-flex align-items-center">
                        <i class="fa fa-circle ${statusIconClass} me-1"></i> ${statusText}
                    </div>
                </td>
                <td>
                    <div class="text-center">
                        <a href="/property/createad/${property.id}" title="Edit" class="btn btn-primary btn-xxs shadow me-1">Edit ad</a>
                        <a href="#"
                        ${property.blockedbyAdmin != true
                ? `onclick="blockAd('${property.id}')" class="btn btn-primary btn-xxs shadow"`
                : `onclick="unblockAd('${property.id}')" class="badge badge-success btn-xxs shadow"`}>
                ${property.blockedbyAdmin != true?
                `Block Ad` :`Unblock Ad`
                }
</a>

                    </div>
                </td>
            </tr>
        `;
        }

        tableHTML += `
            </tbody>
        </table>
    `;

        userListDiv.innerHTML = tableHTML;

    }
    else {
        $('#list').empty();
        $('#response').html('<h4 class="text-center m-5">No record found</h4>');
    }

}

function getStatusText(status) {
    if (status != true)
        return "unblocked";
    else
        return "blocked";
}

function getStatusClass(status) {
    if (status != true)
        return "text-success";
    else
        return "text-danger";
}
