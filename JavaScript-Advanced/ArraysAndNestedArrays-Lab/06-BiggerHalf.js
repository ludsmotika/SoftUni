function biggerHalf(arr) {
    arr.sort((a, b) => a - b);
let half=arr.slice((arr.length)/2);
return half;
}

biggerHalf([4, 7, 2, 5]);