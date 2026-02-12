const form = document.getElementById('regForm');
const nameInput = document.getElementById('fullName');
const nameError = document.getElementById('nameError');
const pass = document.getElementById('pass');
const repass = document.getElementById('repass');
const passError = document.getElementById('passError');

function validateName() {
    const val = nameInput.value.trim();
    if (val.length <= 3) {
        nameError.style.display = "inline";
        nameInput.style.backgroundColor = "gray";
        return false;
    } else {
        nameError.style.display = "none";
        nameInput.style.backgroundColor = "white";
        return true;
    }
}

function validatePasswords() {
    if (pass.value === "" || repass.value === "" || pass.value !== repass.value) {
        passError.style.display = "inline";
        pass.style.backgroundColor = "gray";
        repass.style.backgroundColor = "gray";
        return false;
    } else {
        passError.style.display = "none";
        pass.style.backgroundColor = "white";
        repass.style.backgroundColor = "white";
        return true;
    }
}

form.addEventListener("submit", function(event) {
    const nameOK = validateName();
    const passOK = validatePasswords();

    if (!nameOK || !passOK) {
        event.preventDefault();
        alert("Plz correct the validation errors first.");
    }
});


// diffrence between innerText and textContent

console.log(document.getElementById("demo").innerText);
// Output: "Hello"

console.log(document.getElementById("demo").textContent);
// Output: "Hello Hidden Text"
