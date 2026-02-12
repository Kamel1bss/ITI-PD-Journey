// [1]
let CreateShape = function(_color){
    if(this.constructor === CreateShape)
        throw new Error("can't create an object from abstract class ");
    this.color = _color
}

CreateShape.prototype.printColor = function(){
    return this.color;
}
CreateShape.prototype.CalcArea = function(){
    return 0;
} 


CreateShape.prototype.CalcPerimeter = function(){
    return 0;
} 

// let shapeObj = new CreateShape("white") // can't happen
// console.log(shapeObj.printColor()) 

// [2]

let createRect = function(_color, _width, _length){
    if(this.constructor === createRect)
        createRect.numOfCreatedRects++;
    CreateShape.call(this, _color)
    this.width = _width;
    this.length = _length
}

createRect.prototype = Object.create(CreateShape.prototype)
createRect.prototype.constructor = createRect
createRect.prototype.CalcArea = function(){
    return this.length * this.width;
}
createRect.prototype.CalcPerimeter = function(){
    return 2 * (this.length + this.width);
} 

createRect.prototype.toString = function(){
    return`Rectangle : 
    color: ${this.color}
    Area: ${this.CalcArea()}cm
    Perimeter: ${this.CalcPerimeter()}cm `;
}

createRect.numOfCreatedRects = 0;
let rect = new createRect("White", 2, 4)
console.log(rect)
console.log(rect.CalcArea())
console.log(rect.CalcPerimeter())
console.log(rect.toString())

let createSquare = function(_color, _length){
    createSquare.numOfCreatedSquares++;
    createRect.call(this, _color, _length, _length)
}

createSquare.prototype = Object.create(createRect.prototype)
createSquare.prototype.constructor = createSquare

createSquare.prototype.toString = function(){
    return`Square : 
    color: ${this.color}
    Area: ${this.CalcArea()}cm
    Perimeter: ${this.CalcPerimeter()}cm `;
}

createSquare.numOfCreatedSquares = 0
console.log(`============================`)
let Square = new createSquare("Red", 4)
console.log(Square)
console.log(Square.CalcArea())
console.log(Square.CalcPerimeter())
console.log(Square.toString())

let rect2 = new createRect("Black", 8, 5)
let Square2 = new createSquare("Yellow", 6)
let shapes = [Square, rect, Square2, rect2]

console.log(`============================`)
shapes.forEach(e => console.log(e.toString()))
console.log(`============================`)

console.log(
`CreatedRectangles: ${createRect.numOfCreatedRects}
CreatedSquares: ${createSquare.numOfCreatedSquares}`);
