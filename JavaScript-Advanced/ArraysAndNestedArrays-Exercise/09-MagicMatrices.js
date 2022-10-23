function checkMatrix(matrix){
    let sum =0;
    for (let index = 0; index < matrix[0].length; index++) {
        sum+=matrix[0][index];
    }

    for (let row = 1; row < matrix.length; row++) {
        let currentRow=0;
        for (let col = 0; col < matrix[row].length; col++) {
            currentRow+=matrix[row][col];
        }
        if(sum!=currentRow){return false;}
    }

    for (let col = 0; col < matrix[0].length; col++) {
        let currentCol=0;
        for (let row = 0; row < matrix.length; row++) {
            currentCol+=matrix[col][row];
        }
        if(sum!=currentCol){return false;}
    }

    return true;
}

console.log(checkMatrix([[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
   
   ));