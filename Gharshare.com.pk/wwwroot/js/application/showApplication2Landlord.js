function showApplication2Landlord(ID)
{
    //debugger;
    $.ajax({
        url: '/application/viewapplication',
        type: "POST",
        dataType: "JSON",
        data: { aid: ID },
        success: function (result) {
            //debugger;
            $('#dvapplication').empty();
            $('#divdocument').removeClass('d-none');
            if (result != null) {
                e = '<embed src="' + result.documentPath + '" width="100%" height="900" />';
                $('#txtAppId').val(result.applicationID);
                var propertyId = result.application.property.uid;
                $('#btnCreateLease').attr('href', '/lease/createlease?ID=' + propertyId + '&primaryTenantId=' + result.application.applicantID);
                //$('#spanName').html('Name:' + result.applicant.name);
                //$('#spanEmail').html('Email:' + result.applicant.email);
                //debugger;
                if (result.application.status == 3) {
                    $('#btnCreateLease').addClass('disabled');
                    $('#btnReject').addClass('disabled');
                }
                else {
                    $('#btnCreateLease').removeClass('disabled');
                    $('#btnReject').removeClass('disabled');
}
            }
            else
                e = '<strong>No application found </strong>';
            $('#dvapplication').append(e);
        }, error: function (xhr, status, error) {
            debugger;
            // Handle the error response                                     
            swal.fire(
                {
                    icon: 'error',
                    title: 'Error',
                    text: xhr.responseText,
                    showConfirmButton: false,
                    timer: 2000,
                }
            );
        }
    })
}