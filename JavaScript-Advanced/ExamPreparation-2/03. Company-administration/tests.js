const { assert } = require("chai");
const { companyAdministration } = require("./companyAdministration");

describe("Testing companyAdministration class", () => {

    describe("Testing hiringEmployee function", () => {

        it("should throw an error with some other position than Programmer", () => {
            assert.throw(() => { companyAdministration.hiringEmployee("Petar", "Doctor", 5) }, `We are not looking for workers for this position.`);
            assert.throw(() => { companyAdministration.hiringEmployee("Viktor", "Receptionist", 19) }, `We are not looking for workers for this position.`);
            assert.throw(() => { companyAdministration.hiringEmployee("Svetlin", "Vet", 3) }, `We are not looking for workers for this position.`);
        });

        it("Should not accept the programmer if he doesnt have enough experience", () => {
            let answer1 = companyAdministration.hiringEmployee("Petar", "Programmer", 1);
            let answer2 = companyAdministration.hiringEmployee("Viktor", "Programmer", 2);
            let answer3 = companyAdministration.hiringEmployee("Ivan", "Programmer", 0);
            assert.equal(answer1, "Petar is not approved for this position.");
            assert.equal(answer2, "Viktor is not approved for this position.");
            assert.equal(answer3, "Ivan is not approved for this position.");
        });

        it("Should hire programmer if he has enough experience", () => {

            let answer1 = companyAdministration.hiringEmployee("Petar", "Programmer", 6);
            let answer2 = companyAdministration.hiringEmployee("Viktor", "Programmer", 5);
            let answer3 = companyAdministration.hiringEmployee("Ivan", "Programmer", 3);
            assert.equal(answer1, "Petar was successfully hired for the position Programmer.");
            assert.equal(answer2, "Viktor was successfully hired for the position Programmer.");
            assert.equal(answer3, "Ivan was successfully hired for the position Programmer.");
        });
    });



    describe("Testing calculateSalary function", () => {

        it("should throw with invalid input", () => {
            assert.throw(() => companyAdministration.calculateSalary("lorem ipsum"), "Invalid hours");
            assert.throw(() => companyAdministration.calculateSalary([3, 4, 5]), "Invalid hours");
            assert.throw(() => companyAdministration.calculateSalary(true), "Invalid hours");
            assert.throw(() => companyAdministration.calculateSalary({ hours: 4 }), "Invalid hours");
            assert.throw(() => companyAdministration.calculateSalary(-3), "Invalid hours");
        });

        it("Should return correct answer without bonus", () => {

            assert.equal(companyAdministration.calculateSalary(160), 2400);
            assert.equal(companyAdministration.calculateSalary(100), 1500);
            assert.equal(companyAdministration.calculateSalary(1), 15);
            assert.equal(companyAdministration.calculateSalary(50), 750);
        });

        it("Correct salary, the employee has been working for more than 160 hours", () => {

            assert.equal(companyAdministration.calculateSalary(161), 161 * 15 + 1000);
            assert.equal(companyAdministration.calculateSalary(200), 200 * 15 + 1000);

        });

    });

    describe("Testing firedEmployee function", () => {

        it("Should throw an error with invalid input", () => {
            assert.throw(() => { companyAdministration.firedEmployee(true, false); }, "Invalid input");
            assert.throw(() => { companyAdministration.firedEmployee(true, 3); }, "Invalid input");
            assert.throw(() => { companyAdministration.firedEmployee(["Pepi", "Gosho", "Viki"], false); }, "Invalid input");
            assert.throw(() => { companyAdministration.firedEmployee(["Pepi", "Gosho", "Viki"], { number: 3 }); }, "Invalid input");
            assert.throw(() => { companyAdministration.firedEmployee("Viktor", 3); }, "Invalid input");
            assert.throw(() => { companyAdministration.firedEmployee(3, 3); }, "Invalid input");
            assert.throw(() => { companyAdministration.firedEmployee({ array: ["Pepi", "Gosho", "Viki"] }, 2); }, "Invalid input");
            assert.throw(() => { companyAdministration.firedEmployee(["Pepi", "Gosho", "Viki"], 3); }, "Invalid input");
            assert.throw(() => { companyAdministration.firedEmployee(["Pepi", "Gosho", "Viki"], 5); }, "Invalid input");
            assert.throw(() => { companyAdministration.firedEmployee(["Pepi", "Gosho", "Viki"], -1); }, "Invalid input");
        });

        it("Should remove empoloyee when the input is valid", () => {

            let answer1 = companyAdministration.firedEmployee(["Pepi", "Gosho", "Viki"], 0);
            let answer2 = companyAdministration.firedEmployee(["Pepi", "Gosho", "Viki"], 1);
            let answer3 = companyAdministration.firedEmployee(["Pepi", "Gosho", "Viki"], 2);
            let answer4 = companyAdministration.firedEmployee(["Pepi"], 0);

            assert.equal(answer1, "Gosho, Viki");
            assert.equal(answer1, "Gosho, Viki");
            assert.equal(answer2, "Pepi, Viki");
            assert.equal(answer3, "Pepi, Gosho");
            assert.equal(answer4, "");
        });
    });
});