// =========================================
// a. Types
// =========================================

type User = {
  id: number;
  name: string;
  email: string;
};

let username: string = "Kamel";
let age: number = 30;
let isActive: boolean = true;
let scores: number[] = [95, 87, 92];

let ahmed: User = {
  id: 1,
  name: "Kamel",
  email: "Kamel@example.com",
};

console.log("=== Types ===");
console.log(username, age, isActive, scores);
console.log(ahmed);


// =========================================
// b. Union Types
// =========================================

let id: string | number;
id = 101;
id = "A-101";

type Status = "active" | "inactive" | "pending";
let userStatus: Status = "pending";

let middleName: string | null = null;

console.log("\n=== Union Types ===");
console.log(id, userStatus, middleName);


// =========================================
// c. Function with Typed Arguments and Return Type
// =========================================

function add(a: number, b: number): number {
    return a + b;
}

const greet = (name: string, age: number): string => {
    return `Hello, ${name}! You are ${age} years old.`;
};

function sendMessage(message: string, to?: string): void {
    console.log(`[${to ?? "INFO"}] ${message}`);
}

console.log("\n=== Typed Functions ===");
console.log(add(3, 7));
console.log(greet("kamel", 23));


// =========================================
// d. Enum in TypeScript
// =========================================

enum Direction {
  Up,
  Down,
  Left,
  Right,
}

enum Color {
  Red = "RED",
  Green = "GREEN",
  Blue = "BLUE",
}

console.log("\n=== Enums ===");
console.log(Direction.Up);                        // 0
console.log(Color.Green);                         // "GREEN"


// =========================================
// 2. Class Point2D with constructor and distance method
// =========================================

class Point2D {
  x: number;
  y: number;

  constructor(x: number, y: number) {
    this.x = x;
    this.y = y;
  }

  distanceTo(other: Point2D): number {
    const dx = other.x - this.x;
    const dy = other.y - this.y;
    return Math.sqrt(dx * dx + dy * dy);
  }
}

console.log("\n=== Point2D ===");
const p1 = new Point2D(0, 0);
const p2 = new Point2D(3, 4);
console.log(`Distance between (${p1.x},${p1.y}) and (${p2.x},${p2.y}): ${p1.distanceTo(p2)}`); // 5


// =========================================
// 3. Class Point3D inherits Point2D, adds z and overrides distanceTo
// =========================================

class Point3D extends Point2D {
  z: number;

  constructor(x: number, y: number, z: number) {
    super(x, y);
    this.z = z;
  }

  distanceTo(other: Point3D): number {
    const dx = other.x - this.x;
    const dy = other.y - this.y;
    const dz = other.z - this.z;
    return Math.sqrt(dx * dx + dy * dy + dz * dz);
  }
}

console.log("\n=== Point3D ===");
const p3 = new Point3D(0, 0, 0);
const p4 = new Point3D(1, 2, 2);
console.log(`Distance between (${p3.x},${p3.y},${p3.z}) and (${p4.x},${p4.y},${p4.z}): ${p3.distanceTo(p4)}`); // 3