function sequense(n, k) {
    let arr = [1];
    while (arr.length < n) {
        let current = 0;
        for (let index = arr.length - k; index < arr.length; index++) {
            if (typeof(arr[index]) == "number") {
                current += arr[index];
            }

        }
        arr.push(current);
    }
    return arr;
}


sequense(8,2)