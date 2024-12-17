// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function checkQuery() {
    if (document.getElementById("GenreId").value === "X" &&
        document.getElementById("AuthorId").value === "X" &&
        document.getElementById("PublisherId").value === "X") {
        alert("Select atleast one criteria.");
        document.getElementById("GenreId").focus();
        return false;
    } else {
        document.frmquery.submit();
    }
}

//function signOut() {
//    console.log('signOut called');
//    var auth2 = gapi.auth2.getAuthInstance();
//    auth2.signOut().then(function () {
//        console.log('signOut called 2');
//        alert("User signed out.");
//        console.log('signOut called 3');
//    });

//    alert('test2');
//    //document.frmlogout.submit();
//}


//function handleSignOut(event) {
//    // Prevent the default action of the anchor (which is to navigate to the href)
//    event.preventDefault();

//    var auth2 = gapi.auth2.getAuthInstance();
//    if (auth2) {
//        auth2.signOut().then(function () {
//            console.log('User signed out from Google');
//            alert("User signed out.");
//            // Delay navigation slightly to ensure sign-out process completes
//            /*setTimeout(function () {
//                window.location.href = event.target.href;
//            }, 500); */// 500ms delay (adjust if necessary)
//        }).catch(function (error) {
//            console.log('Error signing out:', error);
//            // If there's an error, navigate immediately
//            window.location.href = event.target.href;
//        });
//    } else {
//        console.log('auth2 is null, initialization might have failed.');
//        window.location.href = event.target.href;
//    }
//}
//function initGoogleAuth() {
//    gapi.load('auth2', function () {
//        gapi.auth2.init({
//            client_id: '93232668655-oldjpt0ht95l5etl2cmglohetgbjiut4.apps.googleusercontent.com'
//        }).then(function () {
//            console.log('Google Auth Initialized');
//        });
//    });
//}

//function signOut() {
//    console.log('SignOut function triggered');
//    var auth2 = gapi.auth2.getAuthInstance();
//    auth2.signOut().then(function () {
//        console.log('User signed out from Google');
//        alert("User signed out.");
//    });
//}

//window.onload = function () {
//    console.log('Window loaded');
//    initGoogleAuth();
//};
//function onSignIn(googleUser) {
//    var profile = googleUser.getBasicProfile();
//    console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
//    console.log('Name: ' + profile.getName());
//    console.log('Image URL: ' + profile.getImageUrl());
//    console.log('Email: ' + profile.getEmail()); // This is null if the 'email' scope is not present.
//}

