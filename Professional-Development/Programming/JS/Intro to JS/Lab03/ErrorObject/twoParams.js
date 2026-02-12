function onlyTwo(a, b) {
    if (arguments.length !== 2) {
        throw new Error("Function requires exactly 2 parameters.");
    }
    return [a, b];
}

console.log(onlyTwo(1, 2));