function oddPos(arr){
    let processedArr= [];
    for (let index = 1; index < arr.length; index+=2) {
        processedArr.push(arr[index]*2);
    }
    return processedArr.reverse();
}

