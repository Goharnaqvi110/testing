function toggleCheckboxes() {
    var checkAllCheckbox = document.getElementById("checkAll");
    var checkboxes = document.querySelectorAll('.form-check-input');

    checkboxes.forEach(function (checkbox) {
        checkbox.checked = checkAllCheckbox.checked;
    });
}