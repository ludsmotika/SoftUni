function negativeToPossitiveArray(arr) {
    let sortedArr = [];
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] < 0) {
            sortedArr.unshift(arr[i]);
        }
        else {
            sortedArr.push(arr[i]);
        }

    }
    console.log(sortedArr.join('\n'));
}
