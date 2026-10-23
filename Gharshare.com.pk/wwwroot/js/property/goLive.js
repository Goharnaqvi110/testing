function changeAdStatus(element, propertyid) {     
    //debugger;
    if (propertyid != "") {
        var textMsg;
        var title;
        let stat;
        var icon;
        if ($(element).text().trim() === 'Go live') {
            title = "Confirm making your ad live?";
            textMsg = "Your property advertisement will go live on our website."; 
            icon = "info";
            stat = 1; //go live
        }
        else {
            title = "Confirm removing your property advertisement?";
            textMsg = "Your property advertisement will be removed from our website.";
            icon = "warning";
            stat =2 //remove ad;
        }
        //debugger;
            //// confirm change status
            Swal.fire({
                title: title,
                text: textMsg,
                icon: icon,
                showCancelButton: true,
                confirmButtonColor: '#FF005D',
                cancelButtonColor: '#082642',
                confirmButtonText: 'Yes change status!'
            }).then((result) => {
                if (result.isConfirmed) {
                    /// ajax call to delete account starts
                    $.ajax({
                        url: '/property/changeAdstatus?pid=' + encodeURIComponent(propertyid) + '&&status=' + encodeURIComponent(stat),                         
                        success: function (data) {
                            /*if ($(element).text() === 'Go live') {*/
                            if (stat === 1) {
                                $(element).text('Remove ad');
                            }
                            else {
                                $(element).text('Go live');
                            }
                            // window.location = "/home/";
                            swal.fire(
                                {
                                    icon: 'success',
                                    title: 'Success',
                                    text: 'Ad status changed successfully.',
                                    showConfirmButton: false,
                                    timer: 2000,
                                }
                            );
                        },
                        error: function (xhr, status, error) {
                            swal.fire(
                                {
                                    icon: 'error',
                                    title: 'Error',
                                    text: 'internal server occur making your ad go live.',
                                    showConfirmButton: false,
                                    timer: 2000,
                                }
                            );
                        }
                    });
                    /// End of ajax call to delete account

                }
            })

            /////

        }
    }