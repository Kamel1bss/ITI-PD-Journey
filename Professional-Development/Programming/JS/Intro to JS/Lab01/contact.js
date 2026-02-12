function contactPage() {

    let name;
    do {
        name = prompt("Enter your name:");
    } while (!name || !isNaN(name));

    let birthYear;
    do {
        birthYear = prompt("Enter your birth year (must be < 2010):");
    } while (isNaN(birthYear) || birthYear >= 2010 || birthYear.trim() === "");

    birthYear = Number(birthYear);
    let age = 2025 - birthYear;

    document.write(`<p><b>Name:</b> ${name}</p>`);
    document.write(`<p><b>Birth year:</b> ${birthYear}</p>`);
    document.write(`<p><b>Age:</b> ${age}</p>`);
}

contactPage();
