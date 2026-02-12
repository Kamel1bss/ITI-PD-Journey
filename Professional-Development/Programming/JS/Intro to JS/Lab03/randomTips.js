let tips = [
    "Use === instead of == for strict comparison.",
    "Use let and const instead of var.",
    "Arrays in JavaScript are dynamic.",
    "Use template literals instead of string concatenation.",
    "Arrow functions keep the 'this' value of their environment.",
    "Use console.log() for debugging.",
    "JSON is the most common data format in JS.",
    "Use map/filter/reduce for cleaner array operations.",
    "Always handle errors using try…catch."
];

let randomIndex = Math.floor(Math.random() * tips.length);
document.write("<h2>Tip of the day:</h2>" + tips[randomIndex]);