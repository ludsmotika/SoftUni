const { assert } = require('chai');
const { chooseYourCar } = require('./chooseYourCar');

describe("Testing chooseYourCar object!", () => {

    describe("Testing choosingType method!", () => {

        it("Should throw error 'Invalid Year!'", () => {
            assert.throw(() => { chooseYourCar.choosingType('lorem ipsum', 'lorem ipsum', 1899) }, `Invalid Year!`);
            assert.throw(() => { chooseYourCar.choosingType('lorem ipsum', 'lorem ipsum', 1800) }, `Invalid Year!`);
            assert.throw(() => { chooseYourCar.choosingType('lorem ipsum', 'lorem ipsum', 2023) }, `Invalid Year!`);
            assert.throw(() => { chooseYourCar.choosingType('lorem ipsum', 'lorem ipsum', 2100) }, `Invalid Year!`);
        });

        it("Should throw if the type is not Sedan", () => {
            assert.throw(() => { chooseYourCar.choosingType('Combi', 'red', 1900) }, `This type of car is not what you are looking for.`);
            assert.throw(() => { chooseYourCar.choosingType('Cabrio', 'red', 2022) }, `This type of car is not what you are looking for.`);
            assert.throw(() => { chooseYourCar.choosingType('lorem Ipsum', 'red', 2000) }, `This type of car is not what you are looking for.`);
            assert.throw(() => { chooseYourCar.choosingType('chevy', 'red', 2005) }, `This type of car is not what you are looking for.`);
        });

        it("Should return that the car doesn`t match my requirements!", () => {
            let answer1 = chooseYourCar.choosingType("Sedan", 'red', 2009);
            let answer2 = chooseYourCar.choosingType("Sedan", 'blue', 1900);
            let answer3 = chooseYourCar.choosingType("Sedan", 'black', 2000);
            let answer4 = chooseYourCar.choosingType("Sedan", 'red', 1999);
            let answer5 = chooseYourCar.choosingType("Sedan", 'red', 2008);

            assert.equal(answer1, `This Sedan is too old for you, especially with that red color.`);
            assert.equal(answer2, `This Sedan is too old for you, especially with that blue color.`);
            assert.equal(answer3, `This Sedan is too old for you, especially with that black color.`);
            assert.equal(answer4, `This Sedan is too old for you, especially with that red color.`);
            assert.equal(answer5, `This Sedan is too old for you, especially with that red color.`);
        });

        it("Should return that the car meets my requirements", () => {
            let answer1 = chooseYourCar.choosingType("Sedan", 'red', 2010);
            let answer2 = chooseYourCar.choosingType("Sedan", 'blue', 2016);
            let answer3 = chooseYourCar.choosingType("Sedan", 'black', 2011);
            let answer4 = chooseYourCar.choosingType("Sedan", 'red', 2020);
            let answer5 = chooseYourCar.choosingType("Sedan", 'red', 2022);

            assert.equal(answer1, `This red Sedan meets the requirements, that you have.`);
            assert.equal(answer2, `This blue Sedan meets the requirements, that you have.`);
            assert.equal(answer3, `This black Sedan meets the requirements, that you have.`);
            assert.equal(answer4, `This red Sedan meets the requirements, that you have.`);
            assert.equal(answer5, `This red Sedan meets the requirements, that you have.`);
        });
    });

    describe("Testing brandName method!", () => {
        it("Should throw an error with invalid input!", () => {
            assert.throw(() => { chooseYourCar.brandName(1, 1) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.brandName(true, 1) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.brandName("lorem ipsum", 1) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.brandName([], false) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.brandName(true, false) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.brandName({ arr: ["BMW", "Toyota"] }, 1) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.brandName(["Bmw", 'Toyota'], false) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.brandName(["Bmw", 'Toyota'], { number: 2 }) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.brandName(["Bmw", 'Toyota'], true) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.brandName(["Bmw", 'Toyota'], -1) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.brandName(["Bmw", 'Toyota'], 2) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.brandName(["Bmw", 'Toyota'], 3) }, "Invalid Information!");
        });

        it('Should return right answer!', () => {
            let answer1 = chooseYourCar.brandName(['BMW', 'Toyota', 'Skoda'], 0);
            let answer2 = chooseYourCar.brandName(['BMW', 'Toyota', 'Skoda'], 1);
            let answer3 = chooseYourCar.brandName(['BMW', 'Toyota', 'Skoda'], 2);
            let answer4 = chooseYourCar.brandName(['BMW', 'Toyota', 'Skoda', 'Fiat'], 3);

            assert.equal(answer1, 'Toyota, Skoda');
            assert.equal(answer2, 'BMW, Skoda');
            assert.equal(answer3, 'BMW, Toyota');
            assert.equal(answer4, 'BMW, Toyota, Skoda');
        });
    });

    describe("Testing carFuelConsumption method", () => {
        it("Should throw an error with invalid input", () => {
            assert.throw(() => { chooseYourCar.carFuelConsumption(true, false) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.carFuelConsumption('lorem ipsum', 1) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.carFuelConsumption(1, 'lorem ipsum') }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.carFuelConsumption({ number: 1 }, { number: 1 }) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.carFuelConsumption(true, 1) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.carFuelConsumption(1, false) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.carFuelConsumption({ number: 1 }, { number: 1 }) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.carFuelConsumption(3, 0) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.carFuelConsumption(6, 0) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.carFuelConsumption(0, 1) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.carFuelConsumption(0, 2) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.carFuelConsumption(-1, -1) }, "Invalid Information!");
            assert.throw(() => { chooseYourCar.carFuelConsumption(-5, -5) }, "Invalid Information!");
        });

        it("Should return that the car is not efficient enough!", () => {
            let answer1 = chooseYourCar.carFuelConsumption(10, 1);
            let answer2 = chooseYourCar.carFuelConsumption(100, 8);
            let answer3 = chooseYourCar.carFuelConsumption(50, 4);
            let answer4 = chooseYourCar.carFuelConsumption(20, 10);
            let answer5 = chooseYourCar.carFuelConsumption(200, 20);

            assert.equal(answer1, `The car burns too much fuel - 10.00 liters!`);
            assert.equal(answer2, `The car burns too much fuel - 8.00 liters!`);
            assert.equal(answer3, `The car burns too much fuel - 8.00 liters!`);
            assert.equal(answer4, `The car burns too much fuel - 50.00 liters!`);
            assert.equal(answer5, `The car burns too much fuel - 10.00 liters!`);
        });

        it("Should return that the car is efficient!", () => {

            let answer1 = chooseYourCar.carFuelConsumption(100, 7);
            let answer2 = chooseYourCar.carFuelConsumption(50, 2);
            let answer3 = chooseYourCar.carFuelConsumption(20, 1);
            let answer4 = chooseYourCar.carFuelConsumption(100, 4);
            let answer5 = chooseYourCar.carFuelConsumption(100, 1);

            assert.equal(answer1, `The car is efficient enough, it burns 7.00 liters/100 km.`);
            assert.equal(answer2, `The car is efficient enough, it burns 4.00 liters/100 km.`);
            assert.equal(answer3, `The car is efficient enough, it burns 5.00 liters/100 km.`);
            assert.equal(answer4, `The car is efficient enough, it burns 4.00 liters/100 km.`);
            assert.equal(answer5, `The car is efficient enough, it burns 1.00 liters/100 km.`);
        });
    })
});