function checkTemp(a){
    return a >= 30? 'Hot' : "Cold";
}

let deg = Number(prompt("Enter today's temp: "));
let res = checkTemp(deg);
document.write("Today is ", res);