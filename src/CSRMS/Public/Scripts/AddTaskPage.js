document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("reminder").style.display = "none";
});


function toggleReminderField() {
    var checkbox = document.getElementById("remindercheckbox");
    var reminderDiv = document.getElementById("reminder");

    if (checkbox && reminderDiv) { // Check if elements exist before accessing their properties
        if (checkbox.checked) {
            reminderDiv.style.display = "block";
        } else {
            reminderDiv.style.display = "none";
        }
    } else {

        console.error("One or more elements not found.");
    }
}
