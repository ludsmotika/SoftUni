function sum(arr, startIndex = 0, endIndex = arr.length - 1) {
    if (Array.isArray(arr) == false) {
        return NaN;
    }

    if (startIndex < 0) {
        startIndex = 0;
    }

    if (endIndex >= arr.length) {
        endIndex = arr.length - 1;
    }

    let result = 0;

    for (let index = startIndex; index <= endIndex; index++) {
        result += Number(arr[index]);
    }

    return result;
}


console.log(sum([10, 20, 30, 40, 50, 60], 3, 300));