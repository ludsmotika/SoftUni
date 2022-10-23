function GreatestCommonDivisor(x, y) {
    let smaller;
    let bigger;
    if (x > y) {
        smaller = y;
        bigger = x;
    }
    else {
        smaller = x;
        bigger = y;
    }

    let gcd;

    for (let index = 1; index <= smaller; index++) {
        if (smaller % index == 0 && bigger % index == 0) {
            gcd = index;
        }
    }

    console.log(gcd);
}