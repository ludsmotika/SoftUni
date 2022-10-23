function sortProducts(input) {
    let cheapestProducts = [];
    for (let row of input) {
        current = row.split(" | ");

        let indexOfProd=cheapestProducts.map(p=>p.prodName).indexOf(current[1]);

        if (indexOfProd!==-1) {
            if (cheapestProducts[indexOfProd].price > Number(current[2])) {
                cheapestProducts[indexOfProd].cityName=current[0];
                cheapestProducts[indexOfProd].price= Number(current[2]);
            }
        }
        else{
            cheapestProducts.push({
                prodName:current[1],
                cityName:current[0],
                price: Number(current[2])
            });
        }
    }

    for (let prod of cheapestProducts) {
      console.log(`${prod.prodName} -> ${prod.price} (${prod.cityName})`)
    }
}

sortProducts(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 1',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']
);