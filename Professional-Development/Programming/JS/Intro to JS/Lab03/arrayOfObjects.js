let students = [
    { name: "Ahmed", degree: 95 },
    { name: "Sara", degree: 50 },
    { name: "Omar", degree: 88 },
    { name: "Laila", degree: 30 },
    { name: "Mona", degree: 99 }
];

let topStudent = students.find(s => s.degree >= 90 && s.degree <= 100);
console.log("Student with degree 90–100:", topStudent);

let weakStudents = students.filter(s => s.degree < 60);
console.log("Students with degree < 60:");
weakStudents.forEach(s => console.log(s.name));

students.push({ name: "Youssef", degree: 77 });

console.log("After push(), printing with for...in:");
for (let index in students) {
    console.log(students[index]);
}

students.pop();

console.log("After pop(), printing with for...of:");
for (let student of students) {
    console.log(student);
}


students.sort((a, b) => a.name.localeCompare(b.name));
console.log("Sorted students alphabetically:");
console.log(students);


students.splice(2, 0,
    { name: "Hana", degree: 82 },
    { name: "Kareem", degree: 91 }
);

console.log("After adding 2 students after second element:");
console.log(students);


students.splice(4, 1);

console.log("After removing 1 student after the third element:");
console.log(students);
