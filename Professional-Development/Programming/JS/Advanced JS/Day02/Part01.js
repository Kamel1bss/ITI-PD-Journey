let Person = {
    Id : 1,
    Name : "Empty",
}

let Employee = Object.create(Person);

Object.defineProperty(Employee, "Salary", {
    get: function () {
        return this.s;
    },
    set: function (value) {
        this.s = value + (value * 0.20);
    }
})

Employee.Salary = 1000;
console.log(Employee.Salary); // 1200

let HREmployee = Object.create(Employee);
HREmployee.location = "Cairo";

console.log(HREmployee.__proto__ === Employee) // true
console.log(HREmployee.__proto__.__proto__ === Person) // true

console.log(HREmployee.Id); // 1
console.log(HREmployee.Name); // Empty

HREmployee.Id = 2020;
HREmployee.Name = "Kamel";

console.log("HR Id : ", HREmployee.Id); // 2002
console.log("HR Name is ", HREmployee.Name); // Kamel
console.log("Person Name is ", Person.Name); // 1

Person.Age = 23
console.log("HR Age is ", HREmployee.Age) // 23