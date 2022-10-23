function getBottles(arr) {

    let flavorsWithQuantity = {};
    let bottles = {};

    for (let currentRow of arr) {

        let rowInfo = currentRow.split(' => ');

        if (flavorsWithQuantity[`${rowInfo[0]}`] == undefined) {
            flavorsWithQuantity[`${rowInfo[0]}`] = Number(rowInfo[1]);
        }
        else {
            flavorsWithQuantity[`${rowInfo[0]}`] += Number(rowInfo[1]);
        }

        for (let key in flavorsWithQuantity) {
            if (flavorsWithQuantity[key] >= 1000) {
                let toAdd = Math.trunc((flavorsWithQuantity[key] / 1000));
                if (bottles[key] == undefined) {
                    bottles[key] = toAdd;
                }
                else {
                    bottles[key] += toAdd;
                }
                flavorsWithQuantity[key] -= toAdd * 1000;
            }
        }
    }


    for (let key in bottles) {
        console.log(`${key} => ${bottles[key]}`);
    }

}

getBottles(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']

);