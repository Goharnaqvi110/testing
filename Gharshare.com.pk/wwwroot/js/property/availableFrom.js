function Available(availableFrom) {
    var utcNow = new Date();
    var availableFromDate = new Date(availableFrom);

    if (availableFromDate <= utcNow) {
        return 'Available Now';
    } else {
        return 'Available from ' + formatDateToDDMMYY(availableFrom);
    }
}