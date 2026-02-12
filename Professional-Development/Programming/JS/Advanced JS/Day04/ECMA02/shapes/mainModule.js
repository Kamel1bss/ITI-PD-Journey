import { Square } from "./SquareModule.js";
import { Rectangle } from "./RectangleModule.js";
import { Circle } from "./CircleModule.js";
import { Car } from "../cars/CarModule.js";
import { EV } from "../cars/EVModule.js";

// [Part One]
let rec1 = new Rectangle("Red", 5, 6);
let rec2 = new Rectangle("Black", 8, 7);
let square1 = new Square("Blue", 7);
let square2 = new Square("Yellow", 4);
let cir1 = new Circle("Green", 7, 2, 3);
let cir2 = new Circle("White", 13, 4, 5);

let shapes = [rec1, rec2, square1, square2, cir1, cir2]
shapes.forEach(s => s.toString())

console.log(`==================================`)
console.log(`No. of Squares : ${Square.numberOfCreatedSquares}`)
console.log(`No. of Rectangles : ${Rectangle.numberOfCreatedRectangles}`)
console.log(`==================================`)

// [Part Two]
let car1 = new Car("BMW", 120)
let car2 = new Car("Mercedes", 95)
car1.accelerate()
car1.break()

car2.accelerate()
car2.break()

console.log(`==================================`)
// [Part Three]
let ev1 = new EV('Telsa', 120, 23)
ev1.ChargeBattery(90)
ev1.accelerate();
ev1.break();
