function cityTaxes(name, population, treasury) {
    return {
        name,
        population,
        treasury,
        taxRate: 10,
        collectTaxes() {
            this.treasury += this.population * this.taxRate;
            Math.floor(this.treasury);
        },
        applyGrowth(percentage) {
            this.population  *= 1 + ((percentage / 100));
            Math.floor(this.population);
        },
        applyRecession(percentage) {
            this.treasury *=  1-(this.percentage / 100)
            Math.floor(this.treasury);
        }
    }
}


const city =
    cityTaxes('Tortuga',
        7000,
        15000);
city.collectTaxes();
console.log(city.treasury);
city.applyGrowth(5);
console.log(city.population);
