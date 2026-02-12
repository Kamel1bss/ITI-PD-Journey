// [1]
let numbers = [18, 12, 31, 14, 65, 4, 88]
let sortedAsc = structuredClone(numbers)  // deep copy
let sortedDes = structuredClone(numbers);

sortedAsc.sort((a, b) => a - b)
sortedDes.sort((a, b) => b - a)

console.log(numbers)
console.log(`Sorted Asc:  [${sortedAsc}]`)
console.log(`sorted Desc: [${sortedDes}]`)

let numbersLargerThan50 = numbers.filter(n => n > 50)
console.log(`Nums > 50 :  [${numbersLargerThan50}]`)

console.log(`Max : ${Math.max(...numbers)}`)
console.log(`Min : ${Math.min(...numbers)}`)

//////////////////////////////////////////////
// [2]
function performOperation(operator, ...nums){
    let res = eval(nums.join(operator));
    console.log(`result of ${operator} operation for ${nums} is : ${res}`)
}

performOperation('-', 3, 7, 9)

/////////////////////////////////////////////
// [3]
let id = "projectId";
let name = "projectName";
let due = "duration";
let func = "printData";

let project = {
}

project[id] = 133;
project[name] = "AL-Ahly"
project[due] = "3 Months"

project[func] = function(){
    console.log(
        `Project Data:
            Id : ${project.projectId}
            Name : ${project.projectName}
            Duration : ${project.duration}`)
}

project.printData()