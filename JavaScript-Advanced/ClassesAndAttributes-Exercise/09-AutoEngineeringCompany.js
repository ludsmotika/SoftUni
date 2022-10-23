function getCars(arr) {
    let cars = {};
    for (let currentRow of arr) {
        currentRow = currentRow.split(' | ');
        if (cars[currentRow[0]] == undefined) {
            cars[currentRow[0]] = [];
        }

        if (cars[currentRow[0]][currentRow[1]] == undefined) {
            cars[currentRow[0]][currentRow[1]] = Number(currentRow[2]);
        }
        else {
            cars[currentRow[0]][currentRow[1]] += Number(currentRow[2]);
        }
    }


    for (let key in cars) {
        console.log(key);
        let models=cars[key];
        for (let key in models) {
            console.log(`###${key} -> ${models[key]}`);
        }
    }
}



getCars(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']);
