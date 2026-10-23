// Add a JavaScript event listener to ensure full page reload
document.querySelectorAll('.theme-btn-1').forEach(link => {
    link.addEventListener('click', function (e) {
        // Prevent default behavior to manually handle the navigation
        e.preventDefault();

        // Set window.location.href to the link's href attribute
        window.location.href = e.target.getAttribute('href');         
    });
});
// Add a JavaScript event listener to ensure full page reload when logo clicked
document.querySelectorAll('.plogo').forEach(link => {
    link.addEventListener('click', function (e) {
        // Prevent default behavior to manually handle the navigation
        e.preventDefault();

        // Set window.location.href to the link's href attribute
        window.location.href = '/';
    });
});