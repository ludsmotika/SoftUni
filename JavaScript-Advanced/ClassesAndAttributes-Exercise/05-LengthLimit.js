class Stringer {
    constructor(text, length) {
        this.innerString = text;
        this.innerLength = length;
    }

    increase(length) {
        this.innerLength += length;
    }

    decrease(length) {
        this.innerLength -= length;
        if (this.innerLength < 0) {
            this.innerLength = 0;
        }
    }

    toString() {
        let answer;

        if (this.innerLength == 0) {
            answer = '...';
        }
        else if (this.innerLength >= this.innerString.length) {
            answer = this.innerString;
        }
        else if (this.innerLength < this.innerString.length) {
            answer = this.innerString.substr(0, this.innerLength) + '...';
        }

        return answer;
    }
}

let s = new Stringer('Viktor',6);
s.decrease(3);
console.log(s.toString());