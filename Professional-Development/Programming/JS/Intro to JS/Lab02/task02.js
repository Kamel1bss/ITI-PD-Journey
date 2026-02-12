let str = prompt("Enter a string to check if it's a palindrome:");
let caseSensitive = confirm("Do you want case sensitivity?");

let originalStr = str;

if (!caseSensitive) {
    str = str.toLowerCase();
}

let reversed = str.split("").reverse().join("");

if (str === reversed) {
    alert(`"${originalStr}" is a palindrome.`);
} else {
    alert(`"${originalStr}" is NOT a palindrome.`);
}
