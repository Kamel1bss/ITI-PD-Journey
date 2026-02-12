export class Car {
    static #serial = 0;
    #name
    #speed
    constructor(_name, _speed){
        Car.#serial++;
        this.Name = _name,
        this.Speed = _speed
    }

    set Name(_v){
        this.#name = _v
    }

    get Name(){return this.#name}

    set Speed(_v){
        this.#speed = _v;
    }

    get Speed(){return this.#speed}

    accelerate(){
        this.Speed += this.#speed * 0.1
        console.log(`${this.Name} going  at ${this.Speed} km/h`)
    }

    break(){
        this.Speed -= 5
        console.log(`${this.Name} going  at ${this.Speed} km/h`)
    }
}