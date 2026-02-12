// PART 02
const employees = [
    { id: 1, name: "Ahmed", salary: 4000, dept: "IT" },
    { id: 2, name: "Sara",  salary: 5000, dept: "HR" },
    { id: 3, name: "Omar",  salary: 6000, dept: "IT" },
    { id: 4, name: "Mona",  salary: 4500, dept: "Finance" }
];


// [1]
let EmpName = function() {
    return function(emp){
        return emp.name;
    }
}

let getName = EmpName();
console.log(getName(employees[0]));

// [2]
let counter = function(){
    let cnt = 0;
    return function(){
        cnt++;
        return cnt;
    }
}

let cnt = counter();
console.log(cnt());
console.log(cnt());
console.log(cnt());

// [3]
let clickTrack = function(){
    let click = 0;
    const colors = ["red", "blue", "green", "orange", "purple"];
    return function(){
        click++
        document.body.style.backgroundColor =
            colors[click % colors.length];
        console.log(`clicked ${click}`);
    }
}

let Tracker = clickTrack();
document.getElementById("btn").addEventListener("click", Tracker)

// [4]
let addFixed = function(fixed){
    return function (num) {
        num += fixed;
        return num;
    }
}

let add = addFixed(17);
console.log(add(55));

// [5]
let countEmp = function(){
    empcnt = 0;
    return function(){
        empcnt++;
        return empcnt;
    }
}

let empCounter = countEmp();
console.log(empCounter());
console.log(empCounter());
console.log(empCounter());


// [6]
let addBouns = function(percentage){
    return function(emp){
        emp.salary = (emp.salary) + (emp.salary * percentage/100);
        return emp.salary
    }
}

let bouns = addBouns(10);
console.log(bouns(employees[0]));

// [7]
let greetDept = function(emp){
    let deptName = emp.dept
    return function(){
        console.log(`Hi ${emp.name} from ${deptName}`)
    }
}

let greet = greetDept(employees[0])
console.log(greet())

// [8]
let names = employees.map(e => e.name)
console.log(names)

// [9]
let highPayedEmployees = employees.filter(e => e.salary > 4500)
let highPayedEmployeesNames = highPayedEmployees.map(e => e.name)
console.log(highPayedEmployeesNames)

// [10]
let totalSalaries = employees.reduce((sum, e) => sum + e.salary, 0)
console.log(totalSalaries)

// [11]
let purFunc = function(emp){
    let copy = JSON.parse(JSON.stringify(emp));
    copy.salary = copy.salary + (copy.salary * .1)
    return copy;
}

// [12]
let newEmps = employees.map(e => e)
newEmps.push({id: 1111, name: "kamel", salary : 15000, dept : "CS"})
console.log(employees)
console.log(newEmps)

// [13]
function applyBouns(func){
    return function(salary){
        return func(salary);
    }
}

let addBouns2 = applyBouns(sal => sal + sal * .1);
console.log(addBouns2(5000));

// [14]
// let filterEmps = employees => deptName => 
//     employees.filter(e => e.dept == deptName)


let filterEmps = function(employees){
    return function (deptName){
        return employees.filter(e => e.dept == deptName);
    }
}


let filterEmployeesBy = filterEmps(employees)
let filtered = filterEmployeesBy('IT')
console.log(filtered)

// [15]
let changableEmps = employees.map(e => e)
changableEmps.forEach(e => e.salary += e.salary * .05)
console.log(changableEmps)
