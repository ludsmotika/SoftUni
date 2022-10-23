//01

function echo(text) {
    console.log(text.length);
    console.log(text);
}

//02

function calculate(first, second, third) {
    sum = first.length + second.length + third.length;
    average = Math.floor(sum / 3);
    console.log(sum);
    console.log(average);
}

//03

function biggest(x, y, z) {

    let answer = 0;

    if (x >= y && x >= z) {
        answer = x;
    }
    else if (y >= x && y >= z) {
        answer = y;
    }
    else {
        answer = z;
    }
    console.log(`The largest number is ${answer}.`);
}

//04

function area(x) {
    if (typeof x != 'number') {
        console.log(`We can not calculate the circle area, because we receive a ${typeof x}.`);
    }
    else {
        console.log((Math.PI * x * x).toFixed(2));
    }
}

//05

function solve(x, y, operation) {
    let result;

    switch (operation) {
        case '+': result = x + y; break;
        case '-': result = x - y; break;
        case '/': result = x / y; break;
        case '*': result = x * y; break;
        case '%': result = x % y; break;
        case '**': result = x ** y; break;
    }

    console.log(result);
}

//06

function sum(n, m) {
    let start = Number(n);
    let end = Number(m);

    let sum = 0;

    for (let index = start; index <= end; index++) {
        sum += index;
    }

    return sum;
}

//07

function day(text) {

    let result;

    if (text == 'Monday') {
        result = 1;
    }
    else if (text == 'Tuesday') {
        result = 2;
    }
    else if (text == 'Wednesday') {
        result = 3;
    }
    else if (text == 'Thursday') {
        result = 4;
    }
    else if (text == 'Friday') {
        result = 5;
    }
    else if (text == 'Saturday') {
        result = 6;
    }
    else if (text == 'Sunday') {
        result = 7;
    }
    else { result = 'error' }

    console.log(result);
}

//08

function GetLastDayOfTheMonth(month, year) {
    let d = new Date(year, month, 0);
    console.log(d.getDate());
}

//09

function drawStars(num) {
    for (let i = 0; i < num; i++) {
        let result = '';
        for (let k = 0; k < num; k++) {
            result += ' *';
        }
        console.log(result);
    }
}

//10

function getSums(array) {
    let firstSum = 0;
    array.forEach(element => {
        firstSum += element;
    });
    console.log(firstSum);

    let secondSum = 0;
    array.forEach(element => {
        secondSum += 1/element;
    });
    console.log(secondSum);

    let concatenated = '';
    array.forEach(element => {
        concatenated += element;
    });
    console.log(concatenated);
}

