class Hex {
    constructor(value) {
        this.value = value;
    }

    valueOf() {
        return this.value;
    }

    toString() {
        let hexString = '0x' + this.value.toString(16).toUpperCase();
        return hexString;
    }

    plus(number) {
        if (typeof (number)=='number') {
            return new Hex(this.value + number);
        }
        else{
            return new Hex(this.value + number.valueOf())
        }
    }

    minus(number) {
        if (typeof (number)=='number') {
            return new Hex(this.value - number);
        }
        else{
            return new Hex(this.value - number.valueOf())
        }
    }

    parse(string) {
        let yourNumber = parseInt(string, 16);
        return yourNumber;
    }

}

let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString()==='0xF');
console.log(FF.parse('AAA'));
