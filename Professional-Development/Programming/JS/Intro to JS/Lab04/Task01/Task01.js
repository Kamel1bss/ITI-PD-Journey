// get container
let containDiv = document.querySelector(".container");

// create img
createdImg = document.createElement("img");
createdImg.setAttribute("src", "../imgs/image01.jfif");
createdImg.width = 500;
createdImg.height = 200;

// add img
// containDiv.appendChild(createdImg);
containDiv.insertBefore(createdImg, containDiv.firstChild);

let btns = document.querySelectorAll(".btn");

createdP = document.createElement("p");
createdP.textContent = `Elements in container: ${containDiv.childNodes.length}`;

btns[0].addEventListener("click", () => {
    containDiv.appendChild(createdP);
    createdP.textContent = `Elements in container: ${containDiv.childNodes.length}    // this p is counted`;
});

btns[1].addEventListener("click", () => {
    containDiv.removeChild(createdImg);
    createdP.textContent = `Elements in container: ${containDiv.childNodes.length}`;
});

////////////////////////////////////////////////////
