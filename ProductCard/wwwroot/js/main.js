

export function checkMobileScreen() {
    // Get the window's inner width
    var windowWidth = window.innerWidth;

    // Define a threshold width below which it's considered a mobile screen
    var mobileThreshold = 768; // You can adjust this threshold as needed

    // Return true if it's a mobile screen, false otherwise
    return windowWidth < mobileThreshold;
}
