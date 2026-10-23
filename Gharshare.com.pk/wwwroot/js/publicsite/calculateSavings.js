function calculateAnnualSavings() {
    // Get the input values
    //debugger;
    const monthlyRent = parseFloat(document.getElementById('rent').value);
    const agencyManagementFee = parseFloat(document.getElementById('fee').value);

    // Ensure inputs are valid numbers
    if (isNaN(monthlyRent) || isNaN(agencyManagementFee)) {
        document.getElementById('savings-output').innerText = 'Please enter valid numbers for both inputs.';
        return;
    }

    // Constants
    const monthsInYear = 12;
    const listingFee = 200;

    // Calculate annual rent
    const annualRent = monthlyRent * monthsInYear;

    // Calculate agency management fee
    const annualAgencyFee = annualRent * (agencyManagementFee / 100);

    // const annualLeasingFee = monthlyLeasingFee;
    const annualLeasingFee = (monthlyRent) * 2;   

    // Total annual cost
    const totalAnnualCost = annualRent + annualAgencyFee + annualLeasingFee + listingFee;
    
    // Calculate annual savings
    const annualSavings = totalAnnualCost - annualAgencyFee;

    // Output the result
    document.getElementById('savings-output').innerText = `Rs ${annualSavings.toFixed(2)}`;
}

// Add event listener to the fee input
document.getElementById('fee').addEventListener('change', calculateAnnualSavings);