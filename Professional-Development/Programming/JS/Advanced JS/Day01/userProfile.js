let userProfile = {
    name: "",
    age: 0,
    address: {
        street: "",
        city: "",
    },
    getFullAddress: function() {
        return `${this.address.street}, ${this.address.city}`;
    }
}

let users = [],
    addUser = function(user) {
        this.users.push(user);
        console.log(`User "${user.name}" added.`);
    }

    removeUser=function(user) {
        this.users = this.users.filter(u => u.name !== user.name);
        console.log(`User "${user.name}" removed.`);
    }

    listUsers=function() {
        console.log("Current Users:");
        this.users.forEach((u, index) => {
            console.log(`${index + 1}. ${u.name}, Age: ${u.age} Address: ${u.getFullAddress()}`);
        });
    }

    sortUsersByName = function() {
        this.users.sort((a, b) => a.name.localeCompare(b.name));
        console.log("Users sorted by name.");
    }

    sortUsersByAge = function() {
        this.users.sort((a, b) => b.age - a.age);
        console.log("Users sorted by age.");
    }

    filterUsersByAge=function(age) {
        return this.users.filter(u => u.age <= age);
    }


