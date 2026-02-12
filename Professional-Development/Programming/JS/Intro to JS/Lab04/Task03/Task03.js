let header = document.createElement("div");

let input = document.createElement("input");
input.setAttribute("type", "text");
input.setAttribute("placeholder", "Enter your task");
input.style.marginRight = "10px";

let addBtn = document.createElement("button");
addBtn.textContent = "Add";

document.body.appendChild(header);
header.appendChild(input);
header.appendChild(addBtn);


let todos = [];

addBtn.addEventListener("click", () => {
    let todo = document.createElement("div");
    todo.style.marginTop = "10px";
    let task = document.createElement("span");
    task.style.marginRight = "10px";
    task.textContent = input.value == "" ? "No task" : input.value;
    let doneBtn = document.createElement("button");
    doneBtn.textContent = "Done";
    let delBtn = document.createElement("button");
    delBtn.textContent = "Delete";
    document.body.appendChild(todo);
    todo.appendChild(task);
    todo.appendChild(doneBtn);
    todo.appendChild(delBtn);
    todos.push(todo);

    for(let i = 0; i < todos.length; i++){
    todos[i].childNodes[1].addEventListener("click", () => {
        todos[i].childNodes[0].style.textDecoration = "line-through";
    });
}

    for(let i = 0; i < todos.length; i++){
    todos[i].childNodes[2].addEventListener("click", () => {
        todos[i].remove();
    });
}
});

    console.log(todos[0].childNodes[1]); // done
    console.log(todos[0].childNodes[2]); // delete
// console.log(todos[0]);



