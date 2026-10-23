function showHideLandlordDropdown() {
    //debugger;
    // Get the radio button element
    var radioLandlord = document.getElementById("radioLandlord");

    // Get the dropdown element
    var ddlLandlord = document.getElementById("ddlLandlord");
    var ddlTenant = document.getElementById("ddlTenant");

    // Check if the radio button is checked
    if (radioLandlord.checked) {
        // If checked, set the display of ddlLanlord to true
        ddlLandlord.style.display = "block";
        ddlTenant.style.display = "none";
        ddlTenant.disabled = true;
        ddlLandlord.disabled = false;
    } else {
        // If not checked, set the display of ddlLanlord to false
        ddlLandlord.style.display = "none";
        ddlTenant.style.display = "block";
        ddlTenant.disabled = false;
        ddlLandlord.disabled = true;
    }
}