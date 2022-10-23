function neighbors(matrix) {
    let equal = 0;
    for (let i = 0; i < matrix.length-1; i++) {

        for (let k = 0; k < matrix[0].length; k++) {

            if (matrix[i][k] == matrix[i+1][k]) {
                equal++;
            }
            if (matrix[i][k] == matrix[i][k+1]) {
                equal++;
            }
          
        }
    }
    for (let index = 0; index < matrix[0].length; index++) {
        if (matrix[matrix.length-1][index] == matrix[matrix.length-1][index+1]) {
            equal++;
        }
    }

    console.log(equal);
}
