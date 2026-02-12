let imgs = [{}, {}, {}, {}];

// create imgs
for(let i = 0; i < 4; i++){
    imgs[i]["img"] = document.createElement("img");
    imgs[i]["img"].setAttribute("src", `../imgs/image0${i + 1}.jfif`);
    imgs[i]["img"].width = 500;
    imgs[i]["img"].height = 200;
    imgs[i]["img"].style.display = "block";
    imgs[i]["img"].style.margin = "0 10px 10px 0px";
}

// create descs
for(let i = 0; i < 4; i++){
    imgs[i]["desc"] = document.createElement("p");
    imgs[i]["desc"].textContent = `Nature Image ${i + 1}`;
}

let containDiv = document.querySelector(".containter");
containDiv.appendChild(imgs[0]["img"]);
containDiv.appendChild(imgs[0]["desc"]);

let cnt = 0;
let prvBtn = document.createElement("button");
prvBtn.textContent = "Previous";
prvBtn.style.marginRight = "10px";

let nxtBtn = document.createElement("button");
nxtBtn.textContent = "Next";

document.body.appendChild(prvBtn);
document.body.appendChild(nxtBtn);

nxtBtn.addEventListener("click", () => {
    if(cnt < 3){
        if(prvBtn.disabled){
            prvBtn.disabled = false;
        }
        containDiv.removeChild(imgs[cnt]["img"]);
        containDiv.removeChild(imgs[cnt]["desc"]);
        containDiv.appendChild(imgs[++cnt]["img"]);
        containDiv.appendChild(imgs[cnt]["desc"]);
        if(cnt == 3){
            nxtBtn.disabled = true;
        }
    }
});

prvBtn.addEventListener("click", () => {
    if(cnt > 0){
        if(nxtBtn.disabled){
            nxtBtn.disabled = false;
        }
        containDiv.removeChild(imgs[cnt]["img"]);
        containDiv.removeChild(imgs[cnt]["desc"]);
        containDiv.appendChild(imgs[--cnt]["img"]);
        containDiv.appendChild(imgs[cnt]["desc"]);
        if(cnt == 0){
            prvBtn.disabled = true;
        }
    }
});


