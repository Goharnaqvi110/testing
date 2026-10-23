function getPropertyType(type) {
    switch (type) {
        case 1:
            return "House";
        case 2:
            return "Room";
        case 3:
            return "Apartment";
        case 4:
            return "Hostel";
        case 5:
            return "Hostel Room";
        case 6:
            return "Shop";
        case 7:
            return "Office";
        case 8:
            return "Luxury Villa";
        default:
            return "Unknown"; // Handle the case where the type is not recognized
    }
}