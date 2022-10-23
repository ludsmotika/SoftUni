function sortArr(arr) {
    arr.sort((a, b) => a - b);
    let sortedArr = [];
    for (let index = 0; index < (arr.length / 2)-1; index++) {
        sortedArr.push(arr[index]);
        sortedArr.push(arr[arr.length - index - 1]);
    }
    if(arr.length%2==0){
        sortedArr.push(arr[arr.length/2-1]);
        sortedArr.push(arr[arr.length/2]);
    }
    else{
        sortedArr.push(arr[(arr.length-1)/2]);
    }

    return sortedArr;
}

sortArr([1, 3, 52, 48, 63, 31, -3, 18, 56]);