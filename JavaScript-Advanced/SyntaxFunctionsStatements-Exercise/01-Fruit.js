function fruitAmount(fruit, grams, pricePerKilo) {
    let kilos = grams / 1000;
    console.log(`I need $${(kilos * pricePerKilo).toFixed(2)} to buy ${kilos.toFixed(2)} kilograms ${fruit}.`);
}