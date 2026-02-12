import { Car } from "./CarModule.js";

export class EV extends Car{
    #charge
    constructor(_name, _speed, _charge){
        super(_name, _speed)
        this.Charge = _charge
    }

    set Charge(_v){this.#charge = _v}
    get Charge(){return this.#charge}

    ChargeBattery(chargeTo){
        this.Charge = chargeTo;
    }

    accelerate(){
        this.Speed += 20;
        this.Charge--;
        console.log(`${this.Name} going  at ${this.Speed} km/h, with a charge of ${this.Charge}%`)
    }
}