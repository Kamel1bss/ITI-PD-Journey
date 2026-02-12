import { Rectangle } from "./RectangleModule.js"
export class Square extends Rectangle{
    #length
    static numberOfCreatedSquares = 0;
    constructor(_color, _length){
        Square.numberOfCreatedSquares++;
        super(_color, _length, _length)
    }
}

