function updatePropertyCoverImage(input) {
    //debugger;
    if (input.files && input.files[0]) {
        var file = input.files[0];
        var fileType = file.type.toLowerCase();
        var fileSize = file.size;

        // Check if the file type is an image
        if (fileType.startsWith("image/")) {
            uploadCoverImage(input);            
        } else {
            // Display an error message or perform any other action
            //alert("Please select a valid image file.");
            input.value = ""; // Clear the selected file from the input
            console.log('invalid file');
            Swal.fire({
                icon: 'error',
                title: 'Validation Error',
                text: 'Please select a valid image file.',
                showConfirmButton: false,
                //timer: 2000,
            });
        }
    }
}

function uploadCoverImage(input) {
    //debugger;
    if (input.files && input.files[0]) {
        var formData = new FormData();
        formData.append("file", input.files[0]);
        formData.append("propertyID", document.getElementById("txtPropertyId").value);
       // debugger;
        $.ajax({
            url: "/property/updatePropertyCoverImage",
            type: "POST",
            data: formData,
            contentType: false,
            processData: false,
            success: function (filePath) {
                $('#dvCoverImage').empty(); // remove current image
                var html = `<img src="${filePath}" style="height:200px;width:200px;border-radius:10px;" onclick="document.getElementById('file-upload').click();" />`;
                $('#dvCoverImage').append(html);
            },
            error: function (xhr, status, error) {
                console.error("Property cover image could not be updated!", error);
            }
        });
    }
}
