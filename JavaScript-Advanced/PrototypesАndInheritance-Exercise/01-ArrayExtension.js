(function extendArray() {
    Array.prototype.last = function () {
        return this[this.length - 1];
    }

    Array.prototype.skip = function (n) {
        return this.slice(n);
    }

    Array.prototype.take = function (n) {
        return this.slice(0, n);
    }

    Array.prototype.sum = function () {
        return this.reduce(function (sum, i) {
            return sum + i;
        });
    }

    Array.prototype.average = function () {
        return this.sum() / this.length;
    }
})();


extendArray();

let arr= [1,2,4];
console.log(arr.last());