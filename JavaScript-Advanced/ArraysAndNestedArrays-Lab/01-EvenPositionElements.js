function getEvenPosSum(array) {
    let newArray = 0;
    newArray = array.filter((element, index) => {
        return index % 2 === 0;
    });
    console.log(newArray.join(' '));
}
