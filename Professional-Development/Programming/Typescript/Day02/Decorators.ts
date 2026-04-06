//^ Example of Decorators in TypeScript

// A class decorator that adds a static property to the class
function AddStaticProperty(target: Function) {
    target.prototype.staticProperty = "I am a static property";
}

@AddStaticProperty
class MyClass {
    // Class implementation
}

// Accessing the static property added by the decorator
console.log((MyClass as any).staticProperty); // Output: "I am a static property"

////////////////////////////////////////////////////////////////////////////////&