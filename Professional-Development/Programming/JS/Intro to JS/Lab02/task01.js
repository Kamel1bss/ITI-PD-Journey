let str = prompt("Enter a string:");
let ch = prompt("Enter the character you want to count:");
let caseSensitive = prompt("Do you want case sensitivity? (yes/no)");

let count = 0;

if (caseSensitive.toLowerCase() === "no") {
    str = str.toLowerCase();
    ch = ch.toLowerCase();
}

for (let i = 0; i < str.length; i++) {
    if (str[i] === ch) {
        count++;
    }
}

alert(`The character "${ch}" appears ${count} time(s).`);
