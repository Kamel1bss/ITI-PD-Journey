let todoLists = {
    tasks: [],
    addTask: function(task) {
        this.tasks.push({ task });
        console.log(`Task "${task}" added.`);
    },
    removeTask: function(task) {
        this.tasks = this.tasks.filter(t => t.task !== task);
        console.log(`Task "${task}" removed.`);
    },
    listTasks: function() {
        console.log("Current Tasks:");
        this.tasks.forEach((t, index) => {
            console.log(`${index + 1}. ${t.task}`);
        });
    }
}
for(let i = 1; i <= 5; i++) {
    todoLists.addTask(`Task ${i}`);
}
todoLists.listTasks();
todoLists.removeTask("Task 4");
todoLists.listTasks();