$(document).ready(function () {    
    // Add event listener to all input elements with class 'integeronly'
    var integerOnlyInputs = document.querySelectorAll('.integeronly');

    integerOnlyInputs.forEach(function (input) {
        input.addEventListener('input', function (event) {
            //debugger;
            // Get the input value and remove non-numeric characters
            var inputValue = event.target.value.replace(/[^0-9]/g, '');

            // Update the input value with only numeric characters
            event.target.value = inputValue;
        });
    });
});