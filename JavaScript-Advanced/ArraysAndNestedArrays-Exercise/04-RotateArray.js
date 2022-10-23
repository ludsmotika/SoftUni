function rotateArr(arr, n){
    for (let index = 0; index < n; index++) {
        rotate(arr);
    }

    function rotate(array){
        let save=array[array.length-1];
        for (let index = arr.length-1; index > 0; index--) {
            arr[index]=arr[index-1];
        }
        arr[0]=save;
    }

    console.log(arr.join(' '));
}

rotateArr(['1', 
'2', 
'3', 
'4'], 
2
);