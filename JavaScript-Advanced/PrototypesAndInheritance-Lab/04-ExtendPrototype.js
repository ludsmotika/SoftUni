function extendProrotype(classToExtend) {
    classToExtend.prototype.species = 'Human';
    classToExtend.prototype.toSpeciesString = function () {
        return `I am a ${this.species}. ${this.toString()}`;
    }
}

class Person {
    constructor(name, email) {
        this.name = name,
            this.email = email
    }
}

extendProrotype(Person);


let p = new Person('pepi', 'petrov');
console.log(p.species);

console.log(p.toSpeciesString());