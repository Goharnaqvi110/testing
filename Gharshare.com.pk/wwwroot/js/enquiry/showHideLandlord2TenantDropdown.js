function showLandlord2TenantDropdown() {
    // Get the radio button element
    var radioTenant = document.getElementById("radioLandlord2Tenant");
    // Get the dropdown element
    var ddlTenant = document.getElementById("ddlLandlord2Tenant");
    // Check if the radio button is checked
    if (radioTenant.checked) {
        // If checked, set the display of ddlTenant to true
        ddlTenant.style.display = "block";
        ddlTenant.disabled = false;
    } else {
        // If not checked, set the display of ddlTenant to false
        ddlTenant.style.display = "none";
        ddlTenant.disabled = true;
    }
}
function HideLandlord2TenantDropdown() {
    // Get the radio button element
    var radioAdmin = document.getElementById("radioAdmin");
    // Get the dropdown element
    var ddlTenant = document.getElementById("ddlLandlord2Tenant");
    // Check if the radio button is checked
    if (radioAdmin.checked) {
        // If checked, set the display of ddlLanlord to true
        ddlTenant.style.display = "none";
        ddlTenant.disabled = true;
    } else {
        // If not checked, set the display of ddlLanlord to false
        ddlTenant.style.display = "block";
        ddlTenant.disabled = false;
    }
}
