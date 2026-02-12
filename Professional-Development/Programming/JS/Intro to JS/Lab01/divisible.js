function checkDivisibility(x, y, z) {
    let byY = (x % y === 0);
    let byZ = (x % z === 0);

    if (byY && byZ) {
        document.write(`${x} is divisible by both ${y} and ${z}`);
    }
    else if (byY) {
        document.write(`${x} is divisible by ${y} only`);
    }
    else if (byZ) {
        document.write(`${x} is divisible by ${z} only`);
    }
    else {
        document.write(`${x} is not divisible by ${y} or ${z}`);
    }
}

let x = Number(prompt("Enter x : "))
let y = Number(prompt("Enter y : "))
let z = Number(prompt("Enter z : "))

checkDivisibility(x, y, z);  
