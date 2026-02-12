import { Shape } from "./ShapeModule.js";
export class Circle extends Shape {
    #radius
    #x
    #y

    constructor(_color, _radius, _x, _y){
        super(_color);
        this.Radius = _radius;
        this.X = _x;
        this.Y = _y;
    }

    set Radius(_v){this.#radius = _v}
    get Radius(){return this.#radius}

    set X(_v){this.#x = _v}
    get X(){return this.#x}
    
    set Y(_v){this.#y = _v;}
    get Y(){return this.#y}
        toString() {
        console.log(
            `${this.constructor.name}'s Data :
            color : ${this.Color}
            Radius  : ${this.Radius} cm
            Center : (${this.X}, ${this.Y})
            `)
    }
}