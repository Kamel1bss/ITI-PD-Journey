function sumValues() {
    let sum = 0;

    while (true) {
        let val = prompt("Enter a number (0 to stop):");
        val = Number(val);
        if (val === 0) break;
        sum += val;
        if (sum > 100) break;
    }

    document.write("Total sum = " + sum);
}

sumValues();