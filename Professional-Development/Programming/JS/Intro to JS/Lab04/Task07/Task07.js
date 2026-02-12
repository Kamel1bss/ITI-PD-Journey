const nameInput = document.getElementById('fullName');
const nameError = document.getElementById('nameError');
const pass = document.getElementById('pass');
const repass = document.getElementById('repass');
const passError = document.getElementById('passError');

// Focus/blur border color
nameInput.addEventListener('focus', () => {
    nameInput.style.border = 'solid 1px blue';
});

nameInput.addEventListener('blur', () => {
nameInput.style.border = '';

const val = nameInput.value.trim();
if (val.length <= 3) {
    nameError.style.display = 'inline';
    nameInput.focus();
    nameInput.select();
    nameInput.style.backgroundColor = 'gray';
} else {
    nameError.style.display = 'none';
    nameInput.style.backgroundColor = 'white';
}});

// Password match validation
repass.addEventListener('blur', () => {
if (pass.value === '' || repass.value === '' || pass.value !== repass.value) {
    passError.style.display = 'inline';
    pass.style.backgroundColor = 'gray';
    repass.style.backgroundColor = 'gray';
} else {
    passError.style.display = 'none';
    pass.style.backgroundColor = 'white';
    repass.style.backgroundColor = 'white';
}});

// Form submission
document.getElementById('regForm').addEventListener('submit', (e) => {
    if (nameError.style.display === 'inline' || passError.style.display === 'inline') {
        e.preventDefault();
}});
