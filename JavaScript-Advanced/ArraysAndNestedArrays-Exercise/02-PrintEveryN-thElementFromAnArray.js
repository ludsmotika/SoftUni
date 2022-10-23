function printArr(array,step){
    let filteredArray=[];
    for (let index = 0; index < array.length; index+=step) {
      filteredArray.push(array[index]);
    }
    return filteredArray;
}

printArr(['5', 
'20', 
'31', 
'4', 
'20'], 
2
);