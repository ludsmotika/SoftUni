function sumDiagonals(matrix) {
    let firstDiagonal = 0;
    let secondDiagonal = 0;
    for (let i = 0; i < matrix.length; i++) {
        firstDiagonal += matrix[i][i];
    }
    for (let i = 0; i < matrix.length; i++) {
            secondDiagonal += matrix[i][matrix[0].length-i-1];
    }
    console.log(`${firstDiagonal} ${secondDiagonal}`)
}
