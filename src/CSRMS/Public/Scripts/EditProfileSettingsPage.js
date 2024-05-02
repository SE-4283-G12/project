document.getElementById("newpassword").style.display = "none";
document.getElementById("confirmnewpassword").style.display = "none";


function togglePasswordFields() {
    var checkbox = document.getElementById("passwordCheckbox");
    var newPasswordDiv = document.getElementById("newpassword");
    var confirmNewPasswordDiv = document.getElementById("confirmnewpassword");

    if (checkbox.checked) {
        newPasswordDiv.style.display = "block";
        confirmNewPasswordDiv.style.display = "block";
    } else {
        newPasswordDiv.style.display = "none";
        confirmNewPasswordDiv.style.display = "none";
    }
}


function validateTwoPasswords() {
    var newPassword = document.getElementById("passwordNew").value;
    var confirmNewPassword = document.getElementById("passwordConfirm").value;
    var newPasswordField = document.getElementById("passwordNew");

    if (newPassword !== confirmNewPassword) {
        newPasswordField.setCustomValidity("Passwords do not match");
    } else {
        newPasswordField.setCustomValidity("");
    }
}


