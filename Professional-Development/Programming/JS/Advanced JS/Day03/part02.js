let Car = function(_name, _speed){
    this.name = _name;
    this.currentSpeed = _speed
}

Car.prototype.accelerate = function(){
    this.currentSpeed = this.currentSpeed + (this.currentSpeed * .1)
    console.log(`${this.name}'s current speed: ${Math.floor(this.currentSpeed)} km/h`)
}

Car.prototype.break = function(){
    this.currentSpeed -= 5;
    console.log(`${this.name}'s current speed: ${Math.floor(this.currentSpeed)} km/h`)
}

let car1 = new Car("BMW", 120)
let car2 = new Car("Mercedas", 95)

car1.accelerate()
car1.accelerate()
car1.accelerate()

car1.break()
car1.break()
car1.break()

console.log("==================================")

car2.accelerate()
car2.accelerate()
car2.accelerate()

car2.break()
car2.break()
car2.break()

// part 3
let EV = function(_name, _speed, _charge){
    Car.call(this, _name, _speed)
    this.charge = _charge
}

EV.prototype = Object.create(Car.prototype);
EV.prototype.constructor = EV;

EV.prototype.chargeBattery = function(chargeTo){
    this.charge = chargeTo
}

EV.prototype.accelerate = function(){
    this.currentSpeed += 20
    this.charge -= 1
    console.log(`${this.name} going at ${Math.floor(this.currentSpeed)} km/h, with charge of ${this.charge}%`)
}
console.log("==================================")
let Ecar = new EV("Tesla", 120, 23)
Ecar.chargeBattery(90)
Ecar.accelerate()