/**
 * Create an arrow function that will be called when an image is selected.
 */
const previewImage = (event) => {
    /**
     * Get the selected files.
     */
    const imageFiles = event.target.files;
    /**
     * Count the number of files selected.
     */
    const imageFilesLength = imageFiles.length;
    /**
     * If at least one image is selected, then proceed to display the preview.
     */
    if (imageFilesLength > 0) {
        /**
         * Get the image path.
         */
        const imageSrc = URL.createObjectURL(imageFiles[0]);
        /**
         * Select the image preview element.
         */
        const imagePreviewElement = document.querySelector("#preview");
        /**
         * Assign the path to the image preview element.
         */
        imagePreviewElement.src = imageSrc;
        /**
         * Show the element by changing the display value to "block".
         */
        imagePreviewElement.style.display = "block";
    }
};

//function previewImage(input) {
//    if (input.files && input.files[0]) {
//        var ImageDir = new FileReader();
//        ImageDir.onload = function (e) {
//            $('#preview-selected-image').attr('src', e.target.result);
//        }
//        ImageDir.readAsDataURL(input.files[0]);
//    }
//}

//function previewImage() {
//    // Get the selected file
//    var file = document.getElementById("Picture").files[0];
//    // Create a FileReader object
//    var reader = new FileReader();
//    // Add an event listener to the onload event of the FileReader object
//    reader.onload = function () {
//        // Get the data URL of the selected file
//        var dataURL = reader.result;
//        // Set the src attribute of the <img> tag to the data URL
//        document.getElementById("preview").src = dataURL;
//    }
//    // Read the selected file
//    reader.readAsDataURL(file);
//    /*$("#picture").on("change", previewImage);*/
//    /*document.getElementById("Picture").addEventListener("change", previewImage);*/
//}


//$('form').submit(function (e) {
//    e.preventDefault(); // Prevent the form from submitting
//    previewImage();
//    var formData = new FormData(this); // Get the form data

//    $.ajax({
//        type: 'POST', // Use the HTTP POST method
//        url: '/Dog/UpdateDogToDatabase', // The URL to send the request to
//        data: formData, // The data to send in the request
//        contentType: false, // Do not set the content type of the request
//        processData: false, // Do not process the data before sending it
//        success: function (data) { // If the request is successful
//            /*$('#message').text('Settings updated successfully!');*/
//            alert('Success');
//            window.location.href = '/Dog';
//        },
//        error: function (data) { // If the request fails
//            /*$('#message').text('Error updating settings. Please try again.');*/
//            alert('Failure');
//        }
//    });
//});