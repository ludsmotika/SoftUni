function biggestElement(matrix) {
    let biggest = Number.MIN_SAFE_INTEGER;
    for (let i = 0; i < matrix.length; i++) {
        for (let k = 0; k < matrix[0].length; k++) {
            if (matrix[i][k] > biggest) {
                biggest = matrix[i][k];
            }
        }
    }
    return biggest;
}
