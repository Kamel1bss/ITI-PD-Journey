let expr = prompt("Enter a math expression (e.g. 5 * 7)");

function calculateSimpleExpression(input) {
    input = input.replace(/\s+/g, "");

    let operator = input.match(/[+\-*/]/);
    if (!operator) {
        throw new Error("Invalid expression");
    }
    operator = operator[0];

    let parts = input.split(operator);
    let num1 = Number(parts[0]);
    let num2 = Number(parts[1]);

    if (isNaN(num1) || isNaN(num2)) {
        throw new Error("Expression must contain two numbers");
    }

    switch (operator) {
        case "+": return num1 + num2;
        case "-": return num1 - num2;
        case "*": return num1 * num2;
        case "/": return num1 / num2;
        default: throw new Error("Unknown operator");
    }
}

let result = calculateSimpleExpression(expr);

alert(`You entered: ${expr}, and the result is: ${result}`);
