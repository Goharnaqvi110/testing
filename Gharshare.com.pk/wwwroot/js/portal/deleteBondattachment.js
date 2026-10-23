function DeleteAttachment(elem) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            var FileId = elem.id;
            //debugger;
            $.ajax({
                url: '/Portal/DeleteAttachment',
                type: "POST",
                dataType: "JSON",
                data: { ID: FileId },
                success: function (response) {                     
                    if ($(elem).closest('div.bond-doc-wrapper').length > 0) {
                        $(elem).closest('div.bond-doc-wrapper').hide();
                    }
                    else {
                        $(elem).prev('a').css('display', 'none');
                        $(elem).css('display', 'none');
                    }

                    swal.fire(
                        {
                            icon: 'success',
                            title: 'Success',
                            text: 'File successfully deleted',
                            showConfirmButton: false,
                            timer: 2000,
                        }
                    );
                }
            })
        }
    })
}
