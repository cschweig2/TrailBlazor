async function firebaseCreateUser(email, password) {
    try {
        await firebase.auth().createUserWithEmailAndPassword(email, password);
        await firebaseEmailSignIn(email, password);
    } catch (error) {
        var errorResult = error.code + ": " + error.message;
        return errorResult;
    };
}

async function firebaseEmailSignIn(email, password) {
    try {
        await firebase.auth().signInWithEmailAndPassword(email, password)
    } catch (error) {
        var errorResult = error.code + ": " + error.message;
        return errorResult;
    }
}

async function firebaseGetCurrentUser() {
    var user = await firebase.auth().currentUser;
    if (user) {
        const JsonUser = JSON.stringify(user);
        return JsonUser;
    } else {
        return null;
    }
}

async function firebaseSignOut() {
    try {
        await firebase.auth().signOut();
        return false;
    } catch (error) {
        return true;
    }
}

async function initializeInactivityTimer(dotnetHelper) {
    var timer;
    let counter = 0;
    document.addEventListener("mousemove", resetTimer);
    document.addEventListener("keypress", resetTimer);
    function resetTimer() {
        if (counter == 0) {
            clearTimeout(timer);
            timer = setTimeout(logout, 20000);
        }
    }
    function logout() {
        dotnetHelper.invokeMethodAsync("LogoutClick");
        counter++;
    }
}

async function getRefreshToken(refreshToken) {
    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/json");
    var raw = JSON.stringify({
        "grant_type": "refresh_token",
        "refresh_token": refreshToken
    });
    var requestOptions = {
        method: 'POST',
        headers: myHeaders,
        body: raw,
        redirect: 'follow'
    };
    const response = await fetch("https://securetoken.googleapis.com/v1/token?key=[API_KEY]", requestOptions)
    const responseText = await response.json();
    return JSON.stringify(responseText);
}