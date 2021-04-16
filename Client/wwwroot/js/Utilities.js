function initializeInactivityTimer(dotnetHelper) {
    var timer;
    document.onmousemove = resetTimer;
    document.onkeypress = resetTimer;

    function resetTimer() {
        clearTimeout(timer);
    }

    function logout() {
        console.log("should logout");
        dotnetHelper.invokeMethodAsync("Logout");
    }

}