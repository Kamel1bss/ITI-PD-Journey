function reverseParams1(...args) {
    return args.reverse();
}

function reverseParams2() {
    return Array.from(arguments).reverse();
}

console.log(reverseParams1(1, 2, 3, 4, 5));
console.log(reverseParams2(1, 2, 3, 4, 5));