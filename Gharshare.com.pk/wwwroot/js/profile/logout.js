// to log out by clicking profile menu
const logoutButton = document.getElementById('logout');
logoutButton.addEventListener('click', function (event) {
    event.preventDefault();
    document.getElementById('logoutForm').submit();
});

/// to log out from bottom link
const logoutbottomButton = document.getElementById('logoutbottom');
logoutbottomButton.addEventListener('click', function (event) {
    event.preventDefault();
    document.getElementById('logoutForm').submit();
});