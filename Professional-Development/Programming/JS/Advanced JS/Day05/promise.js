let mypromise = function(){
    let students = ["Ahmed", "Mohamed", "Khaled"]
    // students = []
    return new Promise((res, rej)=>{
        if(students.length)
            res(students);
        else
            rej("Error loading Students")
    })
}

// [1]
mypromise()
    .then(students => console.log(students)) // resolved
    .catch(error => console.log(error)) // rejected
    //.finally(()=> console.log("promise settled")) // done

// [2]
let delayedData = [{id:1, name:"Kamel"}, {id:2, name:"Nagah"}]
Promise.resolve(delayedData) // resolve promise manually
.then(data =>  console.log(data));

// [3]
Promise.reject(delayedData)
    .catch(err => console.log('Error loading the data'))

// Example
function checkAge(age) {
    if (age < 18)
        return Promise.reject("Under age")
        .catch(err => console.log(`User : ${err}`))
    return Promise.resolve("Allowed")
        .then(allow =>  console.log(`User : ${allow}`));
}

checkAge(19)
checkAge(17)

//////////////////////////////////////////////////////////////////////
// [4]
function loadStudents(){
    let students = ['ahmed', 'moahmed']
    return students
}

function loadCourses(){
    let courses = ['JS', 'C#']
    return courses
}

Promise.all([loadStudents(), loadCourses()])
    .then(([studs, courses])=>{
        console.log(`Students : [${studs}]`)
        console.log(`Students : [${courses}]`)
    })
    .catch(err => console.log("Error loading Studest or courses"))

// [5]
Promise.race([loadStudents(), loadCourses()]) // First promise to finish wins
    .then(res => console.log(`winner ${res}`))