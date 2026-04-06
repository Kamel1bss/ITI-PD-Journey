// Importing the exported members from the module
import Sum, { greet, Person, PI } from './Modules';

// Using the imported function
console.log(greet('Alice')); // Output: Hello, Alice!

// Using the imported class
const person = new Person('Bob', 30);
console.log(person.name); // Output: Bob
// console.log(person.age); // This will cause an error because age is private

// Using the imported constant
console.log(PI); // Output: 3.14159

// Using the default exported function called Add from Modules.ts
console.log(Sum(5, 10)); // Output: 15