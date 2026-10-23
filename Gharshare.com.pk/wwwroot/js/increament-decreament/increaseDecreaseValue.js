        // Get all the plus and minus buttons
    const plusButtons = document.querySelectorAll('.fa-plus');
    const minusButtons = document.querySelectorAll('.fa-minus');

// Add event listeners to each button
plusButtons.forEach(button => {
        button.addEventListener('click', incrementValue);
});

minusButtons.forEach(button => {
        button.addEventListener('click', decrementValue);
});

    // Function to increment the value
    function incrementValue(event) {
  const input = event.target.parentNode.parentNode.querySelector('input[type="text"]');
    const currentValue = parseInt(input.value);

    if (currentValue < 20) {
        input.value = currentValue + 1;
  }
}

    // Function to decrement the value
    function decrementValue(event) {
  const input = event.target.parentNode.parentNode.querySelector('input[type="text"]');
    const currentValue = parseInt(input.value);

  if (currentValue > 0) {
        input.value = currentValue - 1;
  }
}