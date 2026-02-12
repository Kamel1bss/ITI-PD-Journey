createdImg = document.createElement("img");
createdImg.setAttribute("src", "../imgs/image01.jfif");
createdImg.width = 500;
createdImg.height = 200;

document.body.appendChild(createdImg);

let clickable = true;

createdImg.addEventListener("click", () => {
    if(clickable){
        console.log("click");
        createdImg2 = document.createElement("img");
        createdImg2.setAttribute("src", "../imgs/image01.jfif");
        createdImg2.width = 500;
        createdImg2.height = 200;
        document.body.appendChild(createdImg2);
        clickable = false;
    }
});
