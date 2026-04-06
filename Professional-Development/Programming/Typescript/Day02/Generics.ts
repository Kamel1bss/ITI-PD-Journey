//^ Example of Generics in TypeScript

// A generic function
function getFirstElement<T>(arr: T[]): T {
    return arr[0];
}

const numbers = [1, 2, 3];
const strings = ["a", "b", "c"];
const firstNumber = getFirstElement(numbers); // Type inferred as number
const firstString = getFirstElement(strings); // Type inferred as string

////////////////////////////////////////////////////////////////////////////////&

// A generic class
class Box<T> {
    private content: T[];
    constructor(content: T[]) {
        this.content = content;
    }
    getContent(): T[] {
        return this.content;
    }
}

const numberBox = new Box<number>([1, 2, 3]);
const stringBox = new Box<string>(["a", "b", "c"]);

console.log(numberBox.getContent()); // Output: [1, 2, 3]
console.log(stringBox.getContent()); // Output: ["a", "b", "c"]

////////////////////////////////////////////////////////////////////////////////&

// A generic interface
interface Pair<K, V> {
    key: K;
    value: V;
}

const pair1: Pair<number, string> = { key: 1, value: "a" };
const pair2: Pair<string, boolean> = { key: "isActive", value: true };

console.log(pair1); // Output: { key: 1, value: "a" }
console.log(pair2); // Output: { key: "isActive", value: true }
