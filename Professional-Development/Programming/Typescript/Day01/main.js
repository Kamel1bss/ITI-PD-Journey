"use strict";
// =========================================
// a. Types
// =========================================
let username = "Kamel";
let age = 30;
let isActive = true;
let scores = [95, 87, 92];
let ahmed = {
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
let id;
id = 101;
id = "A-101";
let userStatus = "pending";
let middleName = null;
console.log("\n=== Union Types ===");
console.log(id, userStatus, middleName);
// =========================================
// c. Function with Typed Arguments and Return Type
// =========================================
function add(a, b) {
    return a + b;
}
const greet = (name, age) => {
    return `Hello, ${name}! You are ${age} years old.`;
};
function sendMessage(message, to) {
    console.log(`[${to ?? "INFO"}] ${message}`);
}
console.log("\n=== Typed Functions ===");
console.log(add(3, 7));
console.log(greet("kamel", 23));
// =========================================
// d. Enum in TypeScript
// =========================================
var Direction;
(function (Direction) {
    Direction[Direction["Up"] = 0] = "Up";
    Direction[Direction["Down"] = 1] = "Down";
    Direction[Direction["Left"] = 2] = "Left";
    Direction[Direction["Right"] = 3] = "Right";
})(Direction || (Direction = {}));
var Color;
(function (Color) {
    Color["Red"] = "RED";
    Color["Green"] = "GREEN";
    Color["Blue"] = "BLUE";
})(Color || (Color = {}));
console.log("\n=== Enums ===");
console.log(Direction.Up); // 0
console.log(Color.Green); // "GREEN"
// =========================================
// 2. Class Point2D with constructor and distance method
// =========================================
class Point2D {
    x;
    y;
    constructor(x, y) {
        this.x = x;
        this.y = y;
    }
    distanceTo(other) {
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
    z;
    constructor(x, y, z) {
        super(x, y);
        this.z = z;
    }
    distanceTo(other) {
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
