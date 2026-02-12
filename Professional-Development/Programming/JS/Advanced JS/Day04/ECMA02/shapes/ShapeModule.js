export class Shape {
    #color
    constructor(_color){
        if(this.constructor === Shape)
            throw Error("abstract class!");
        this.Color = _color;
    }

    set Color(_v){this.#color = _v}
    get Color() {return this.#color}

    PrintColor(){
        console.log(`${this.constructor}'s color : ${this.Color}`)
    }

    CalcArea = () => 0;
    CalcPerimeter = () => 0;
}
