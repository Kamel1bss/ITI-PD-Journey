import { Shape } from "./ShapeModule.js"
export class Rectangle extends Shape {
    #width
    #height
    static numberOfCreatedRectangles = 0;
    constructor(_color, _width, _height){
        super(_color)
        if(this.constructor === Rectangle)
            Rectangle.numberOfCreatedRectangles++;
        this.Height = _height
        this.Width = _width
    }

    set Width(_v){
        if(_v <= 0)
            throw Error("Width of rectangle should be +ve");
        this.#width = _v
    }
    get Width(){return this.#width}

    set Height(_v){
        if(_v <= 0)
            throw Error("Height of rectangle should be +ve");
        this.#height = _v
    }
    get Height() {return this.#height}
    CalcArea = () =>  this.Height * this.Width;
    CalcPerimeter = () => 2 * (this.Height + this.Width);
    toString() {
        console.log(
            `${this.constructor.name}'s Data :
            color : ${this.Color}
            Area  : ${this.CalcArea()} cm
            Perimeter : ${this.CalcPerimeter()} cm
            `)
    }
}
