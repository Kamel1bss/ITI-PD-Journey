//^ Example of Modules in TypeScript

// Exporting a function from a module
export function greet(name: string): string {
    return `Hello, ${name}!`;
}

// Exporting a class from a module
export class Person {
    private age: number;
    constructor(public name: string, age: number) {
        this.age = age;
    }
}

// Exporting a constant from a module
export const PI = 3.14159;

// Exporting default from a module
export default function add(a: number, b: number): number {
    return a + b;
}

