function blockAd(propertyid) {
    //debugger;
    if (propertyid != "") {         
        //debugger;
        //// confirm change status
        Swal.fire({
            title: "Confirm removing your property advertisement?",
            text: "Your property advertisement will be removed from our website.",
            icon: "warning",
            showCancelButton: true,
            confirmButtonColor: '#FF005D',
            cancelButtonColor: '#082642',
            confirmButtonText: 'Yes, take this ad down!'
        }).then((result) => {
            if (result.isConfirmed) {
                /// ajax call to delete account starts
                $.ajax({
                    url: '/property/changeAdstatus?pid=' + encodeURIComponent(propertyid) + '&blockedByAdminVal=' + true+ '&isAdmin=' + true,
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