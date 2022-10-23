function validityCheck(x1, y1, x2, y2) {
    let first = Math.sqrt(((0-x1)*(0-x1))+((0-y1)*(0-y1)));
    if (first - Math.floor(first) != 0) {
        console.log(`{${x1}, ${y1}} to {0, 0} is invalid`);
    }
    else {
        console.log(`{${x1}, ${y1}} to {0, 0} is valid`);
    }


    let second = Math.sqrt(((0-x2)*(0-x2))+((0-y2)*(0-y2)));
    if (second - Math.floor(second) != 0) {
        console.log(`{${x2}, ${y2}} to {0, 0} is invalid`);
    }
    else {
        console.log(`{${x2}, ${y2}} to {0, 0} is valid`);
    }

    let third = Math.sqrt(((x2-x1)*(x2-x1))+((y2-y1)*(y2-y1)));
    if (third - Math.floor(third) != 0) {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
    }
    else {
        console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
    }
}  