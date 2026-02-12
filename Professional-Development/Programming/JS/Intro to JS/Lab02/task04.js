function validateName(name) {
    return isNaN(name) && name.trim() !== "";
}

function validatePhone(phone) {
    return /^\d{8}$/.test(phone); 
}

function validateMobile(mobile) {
    return /^(010|011|012)\d{8}$/.test(mobile); 
}

function validateEmail(email) {
    return /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(email); 
}

let name;
do {
    name = prompt("Enter your name (letters only):");
} while (!validateName(name));

let phone;
do {
    phone = prompt("Enter your phone number (8 digits):");
} while (!validatePhone(phone));

let mobile;
do {
    mobile = prompt("Enter your mobile number (11 digits, starts with 010/011/012):");
} while (!validateMobile(mobile));

let email;
do {
    email = prompt("Enter your email:");
} while (!validateEmail(email));

let color;
do {
    color = prompt("Choose a color: red, green, or blue").toLowerCase();
} while (!["red", "green", "blue"].includes(color));

let today = new Date().toLocaleDateString();

document.write(
    `<div style="color:${color}; font-size:20px;">
        <h2>Welcome, ${name}!</h2>
        <p>Today's Date: ${today}</p>
        <p><strong>Your Information:</strong></p>
        <p>Name: ${name}</p>
        <p>Phone Number: ${phone}</p>
        <p>Mobile Number: ${mobile}</p>
        <p>Email: ${email}</p>
    </div>`
);
