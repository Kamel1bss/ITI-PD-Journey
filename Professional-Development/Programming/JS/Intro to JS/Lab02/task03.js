function getLargestWord(str) {
    let words = str.split(" ");
    let largest = words[0];

    for (let i = 1; i < words.length; i++) {
        if (words[i].length > largest.length) {
            largest = words[i];
        }
    }

    return largest;
}

let str = prompt("Enter a string:");
let largestWord = getLargestWord(str);
alert(`The largest word in "${str}" is "${largestWord}".`);
