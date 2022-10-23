function getSubArray(arr){
    let newArr=[arr[0]];
    for (let index = 1; index < arr.length; index++) {
        if(arr[index]>=newArr[newArr.length-1]){newArr.push(arr[index])}
    }
    return newArr;
}

getSubArray([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]
    );