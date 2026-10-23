function showHideTenantDropdown() {
    // Get the radio button element
    var radioTenant = document.getElementById("radioTenant");

    // Get the dropdown element
    var ddlTenant = document.getElementById("ddlTenant");
    var ddlLandlord = document.getElementById("ddlLandlord");

    // Check if the radio button is checked
    if (radioTenant.checked) {
        // If checked, set the display of ddlLanlord to true
        ddlTenant.style.display = "block";
        ddlLandlord.style.display = "none";
    } else {
        // If not checked, set the display of ddlLanlord to false
        ddlTenant.style.display = "none";
        ddlLandlord.style.display = "block";
    }
}