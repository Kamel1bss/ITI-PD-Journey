
let pKey = document.querySelector(".key");
let mKey = document.querySelector(".mouse");

document.onkeydown = function (e) {
    let key = e.keyCode;

    let msg = "You pressed key: " + String.fromCharCode(key) + "\nKey ASCII Code: " + key + "\n";
    if (e.altKey) msg += "ALT key pressed\n";
    if (e.ctrlKey) msg += "CTRL key pressed\n";
    if (e.shiftKey) msg += "SHIFT key pressed\n";
    pKey.classList.add("hide");
    mKey.classList.remove("hide");
    alert(msg);
};



document.addEventListener("contextmenu", function (e) {
    e.preventDefault();
    alert("Right click disabled!");
    mKey.classList.add("hide");
    pKey.classList.remove("hide");
});
