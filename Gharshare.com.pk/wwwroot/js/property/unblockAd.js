function unblockAd(propertyid) {
    //debugger;
    if (propertyid != "") {         
        //debugger;
        //// confirm change status
        Swal.fire({
            title: "Confirm making your ad live?",
            text: "Your property advertisement will go live on our website.",
            icon: "info",
            showCancelButton: true,
            confirmButtonColor: '#FF005D',
            cancelButtonColor: '#082642',
            confirmButtonText: 'Yes, change status!'
        }).then((result) => {
            if (result.isConfirmed) {
                /// ajax call to delete account starts
                $.ajax({
                    url: '/property/changeAdstatus?pid=' + encodeURIComponent(propertyid) + '&blockedByAdminVal=' + false + '&isAdmin=' + true,
                    success: function (data) {                         
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
    }
}