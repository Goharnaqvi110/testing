function addRemoveFavouriteProperty(element, propertyid) {     
    debugger;
    if (propertyid != "") {
        var textMsg;
        var title;
        let stat;
        var icon;
        if ($(element).text().trim() === 'Add Property to Favourite List') {
            title = "Confirm adding property to favourites?";
            textMsg = "This property will be added to your favourite list."; 
            icon = "info";
            stat = 1; //add to favourite list
        }
        else {
            title = "Confirm removing your property from favourite list?";
            textMsg = "This property will be removed from your favourite list.";
            icon = "warning";
            stat = 2 //remove from favourite list
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
                    /// ajax call to add/remove property from favourite list
                    $.ajax({
                        url: '/property/changePropertyFavouritestatus?pid=' + encodeURIComponent(propertyid) + '&&status=' + encodeURIComponent(stat),                         
                        success: function (data) {                             
                            if (stat === 1) {
                                $(element).text('Remove Property from Favourite List');
                            }
                            else {
                                $(element).text('Add Property to Favourite List');
                            }                             
                            swal.fire(
                                {
                                    icon: 'success',
                                    title: 'Success',
                                    text: 'Favourite status changed successfully.',
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
                                    text: 'internal server occured changing favourite status.',
                                    showConfirmButton: false,
                                    timer: 2000,
                                }
                            );
                        }
                    });
                    /// End of ajax call

                }
            })
            /////
        }
    }