class List {

    constructor() {
        this.arr = [];
        this.size = this.arr.length;
    }

    add(element) {
        this.arr.push(element);
        this.size = this.arr.length;
        this.arr.sort((a, b) =>  a - b );
    }


    remove(index) {
        if (index < 0 || index >= this.arr.length) {
            throw Error();
        }

        this.arr.splice(index, 1);
        this.size = this.arr.length;
    }

    get(index) {
        if (index < 0 || index >= this.arr.length) {
            throw Error();
        }

        return this.arr[index];
    }

}
