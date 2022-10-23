function catalogue(input) {
    input.sort((a, b) => a.localeCompare(b))
    let result = [];
    for (let current of input) {
        let prodInfo = current.split(" : ");
        let firstLetter = prodInfo[0][0].toUpperCase();
        if (result[`${firstLetter}`] === undefined) {
            result[`${firstLetter}`] = [];
        }

        result[`${firstLetter}`].push({ prodName: prodInfo[0], price: Number(prodInfo[1]) });
    }

    for (let current in result) {
        console.log(current);
        for (let obj of result[current]) {
            console.log(`${obj.prodName}: ${obj.price}`);
        }
      }

}

catalogue(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
);