function solution() {
    let string = '';
    return {
        append: (text)=> {string+=text;},
        removeStart: (n) => {string=string.slice(n)},
        removeEnd: (n) => {string=string.slice(0,string.length-n)}, 
        print: () => {console.log(string)}
    }

}

let secondZeroTest = solution();

secondZeroTest.append('123');
secondZeroTest.append('45');
secondZeroTest.removeStart(2);
secondZeroTest.removeEnd(1);
secondZeroTest.print();

let firstZeroTest = solution();

firstZeroTest.append('hello');
firstZeroTest.append('again');
firstZeroTest.removeStart(3);
firstZeroTest.removeEnd(4);
firstZeroTest.print();
