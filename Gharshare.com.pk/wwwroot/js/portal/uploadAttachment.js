function uploadAttachment(input, number, isAttachment) {
    //debugger;
    if (input.files && input.files[0] && input.files.length <= number) {         
        var formData = new FormData();        
        var files = $('#attachment')[0].files;
        for (var i = 0; i < files.length; i++) {
            formData.append("attachment", files[i]);
        }
        formData.append("ID", document.getElementById("leaseId").value);
        formData.append("isAttachment", isAttachment);
        $.ajax({
            url: "/portal/bondattachement?",
            type: "POST",
            data: formData,
            contentType: false,
            processData: false,
            success: function (data) {
                var message = "";
                if (isAttachment)
                    message = 'file(s) successfully saved';
                else
                    message = 'file(s) successfully uploaded';
                swal.fire(
                    {
                        icon: 'success',
                        title: 'Success',
                        text: message,
                        showConfirmButton: false,
                        timer: 2000,
                    }
                );                              
            },
            error: function (xhr, status, error) {
                console.error("Image upload failed!", error);
            }
        });
    }
    else if (input.files.length > number) {
        swal.fire(
            {
                icon: 'error',
                title: 'Error',
                text: 'You can not upload more than '+number+' files',
                showConfirmButton: false,
                timer: 3000,
            }
        );     

    }
}
