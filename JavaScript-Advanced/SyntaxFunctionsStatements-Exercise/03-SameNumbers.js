function checkForSameNumbers(number) {

    let areSame = true;
    let numberAsString = number.toString();
    let current = numberAsString[0];
    let sum = 0;
    for (let index = 0; index < numberAsString.length; index++) {
        if (!(current === numberAsString[index])) {
            areSame = false;
        }
        sum += Number(numberAsString[index]);
    }

    console.log(areSame);
    console.log(sum);
}