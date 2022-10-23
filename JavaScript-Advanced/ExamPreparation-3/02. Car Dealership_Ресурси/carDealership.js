class CarDealership {

    constructor(name, totalIncome = 0) {
        this.name = name;
        this.availableCars = [];
        this.soldCars = [];
        this.totalIncome = totalIncome;
    }

    addCar(model, horsepower, price, mileage) {

        if (model === '' || horsepower < 0 || price < 0 || mileage < 0 || !Number.isInteger(horsepower)) {
            throw new Error("Invalid input!");
        }

        this.availableCars.push({
            model,
            horsepower,
            price,
            mileage
        });

        return `New car added: ${model} - ${horsepower} HP - ${mileage.toFixed(2)} km - ${price.toFixed(2)}$`;
    }

    sellCar(model, desiredMileage) {

        let carToSell = this.availableCars.find(x => x.model === model);

        let indexOfTheCartoCell = this.availableCars.indexOf(carToSell);
        if (indexOfTheCartoCell === -1) {
            throw new Error(`${model} was not found!`);
        }

        let sellPrice;

        if (carToSell.mileage <= desiredMileage) {
            sellPrice = carToSell.price;
        }
        else if (carToSell.mileage - 40000 <= desiredMileage) {
            sellPrice = carToSell.price * 0.95;
        }
        else {
            sellPrice = carToSell.price * 0.90;
        }

        this.soldCars.push({ model: carToSell.model, horsepower: carToSell.horsepower, soldPrice: sellPrice });
        this.totalIncome += sellPrice;
        this.availableCars.splice(indexOfTheCartoCell, 1);
        return `${model} was sold for ${sellPrice.toFixed(2)}$`;
    }

    currentCar() {
        if (this.availableCars.length === 0) {
            return "There are no available cars";
        }
        let answer = '-Available cars:\n';
        for (let car of this.availableCars) {
            answer += `---${car.model} - ${car.horsepower} HP - ${car.mileage.toFixed(2)} km - ${car.price.toFixed(2)}$\n`;
        }

        return answer.trim();
    }

    salesReport(criteria) {
        if (criteria != 'horsepower' && criteria != 'model') {
            throw new Error("Invalid criteria!");
        }
        let answer = `-${this.name} has a total income of ${this.totalIncome.toFixed(2)}$\n`;
        answer += `-${this.soldCars.length} cars sold:\n`;

        let sorted;
        if (criteria == 'horsepower') {
            sorted = this.soldCars.sort((a, b) => b.horsepower - a.horsepower);
        }
        else if (criteria == 'model') {
            sorted = this.soldCars.sort((a, b) => a.model.localeCompare(b.model));
        }

        for (let car of sorted) {
            answer += `---${car.model} - ${car.horsepower} HP - ${car.soldPrice.toFixed(2)}$\n`;
        }

        return answer.trim();
    }
}

let dealership = new CarDealership('SoftAuto');
dealership.addCar('Toyota Corolla', 100, 3500, 190000);
dealership.addCar('Mercedes C63', 300, 29000, 187000);
dealership.addCar('Audi A3', 120, 4900, 240000);
dealership.sellCar('Toyota Corolla', 230000);
dealership.sellCar('Mercedes C63', 110000);
console.log(dealership.salesReport('model'));

