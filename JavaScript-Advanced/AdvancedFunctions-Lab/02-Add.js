function solution(first) {
    return function (second) {
        return first + second;
    }
}


let add5 = solution(5);
console.log(add5(2));
console.log(add5(3));
