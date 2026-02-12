function printOddNumbers(start, end) {
    for (let i = start; i <= end; i++) {
        if (i % 2 !== 0) { 
            console.log(i);
        }
    }
}

printOddNumbers(1, 20);