function getFibonator() {
    let first = -1;
    let second = 0;
    
    return function fib() {
        result=Math.abs(first)+second;
        let save = Math.abs(first);    
        first = second;
        second += save;
        return result;
    }
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); 