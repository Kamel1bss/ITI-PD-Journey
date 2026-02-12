function addNumbers(...nums) {
    if (nums.length === 0) {
        throw new Error("You must pass at least one number.");
    }

    if (!nums.every(n => typeof n === "number")) {
        throw new Error("All parameters must be numbers only.");
    }

    return nums.reduce((sum, n) => sum + n, 0);
}

addNumbers(1, 2, 3, 4, 5);