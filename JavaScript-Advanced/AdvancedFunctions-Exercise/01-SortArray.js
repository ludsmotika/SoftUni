function sort(numArray,typeOfSorting){
    if(typeOfSorting=='asc'){
        numArray=numArray.sort((a,b)=> a-b)
    }
    else if(typeOfSorting=='desc'){
        numArray=numArray.sort((a,b)=> b-a)
    }
    return numArray;
}

sort([14, 7, 17, 6, 8], 'desc');