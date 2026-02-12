let angle = prompt("Enter an angle to calculate its cos value");
let rad = angle * (Math.PI / 180); 
let cosValue = Math.cos(rad);

document.write("cos " + angle + "° is " + cosValue.toFixed(4));