const { assert } = require('chai');
const { mathEnforcer } = require('./04-MathEnforcer')


describe("Test the mathEnforcer", () => {
    it('Should return undefined with incorrect input', () => {
        //Arrange
        let input1 = 'lorem';
        let input2 = true;
        let input3 = { name: 'lorem' };
        let input4 = [];

        //Act
        let result1 = mathEnforcer.addFive(input1);
        let result2 = mathEnforcer.addFive(input2);
        let result3 = mathEnforcer.addFive(input3);
        let result4 = mathEnforcer.addFive(input4);
        let result5 = mathEnforcer.subtractTen(input1);
        let result6 = mathEnforcer.subtractTen(input2);
        let result7 = mathEnforcer.subtractTen(input3);
        let result8 = mathEnforcer.subtractTen(input4);
        let result9 = mathEnforcer.sum(input1, 2);
        let result10 = mathEnforcer.sum(2, input2);
        let result11 = mathEnforcer.sum(input1, input3);
        let result12 = mathEnforcer.sum(input2, input4);

        //Assert
        assert.equal(result1, undefined);
        assert.equal(result2, undefined);
        assert.equal(result3, undefined);
        assert.equal(result4, undefined);
        assert.equal(result5, undefined);
        assert.equal(result6, undefined);
        assert.equal(result7, undefined);
        assert.equal(result8, undefined);
        assert.equal(result9, undefined);
        assert.equal(result10, undefined);
        assert.equal(result11, undefined);
        assert.equal(result12, undefined);

    });

    it("Should return the number with the additional 5", () => {
        //Arrange
        let number = 2;

        //Act
        let result = mathEnforcer.addFive(number);

        //Assert
        assert.equal(result, 7);
    })

    it("Should return the number with the additional 5", () => {
        //Arrange
        let number = 0;

        //Act
        let result = mathEnforcer.addFive(number);

        //Assert
        assert.equal(result, 5);
    })

    it("Should return the number with the additional 5", () => {
        //Arrange
        let number = -5;

        //Act
        let result = mathEnforcer.addFive(number);

        //Assert
        assert.equal(result, 0);
    })

    it("Should return the number with the additional 5", () => {
        //Arrange
        let number = 2.5;

        //Act
        let result = mathEnforcer.addFive(number);

        //Assert
        assert.closeTo(result, 7.5, 0.1);
    })

    it("Should return the number with the additional 5", () => {
        //Arrange
        let number = -2.5;

        //Act
        let result = mathEnforcer.addFive(number);

        //Assert
        assert.closeTo(result, 2.5, 0.1);
    })

    it("Should subtract 10 from the number!", () => {
        //Arrange
        let number = 0;

        //Act
        let result = mathEnforcer.subtractTen(number);

        //Assert
        assert.equal(result, -10);
    })

    it("Should subtract 10 from the number!", () => {
        //Arrange
        let number = 10;

        //Act
        let result = mathEnforcer.subtractTen(number);

        //Assert
        assert.equal(result, 0);
    })

    it("Should subtract 10 from the number!", () => {
        //Arrange
        let number = -20;

        //Act
        let result = mathEnforcer.subtractTen(number);

        //Assert
        assert.equal(result, -30);
    })

    it("Should subtract 10 from the number!", () => {
        //Arrange
        let number = 8.5;

        //Act
        let result = mathEnforcer.subtractTen(number);

        //Assert
        assert.closeTo(result, -1.5, 0.1);
    })

    it("Should subtract 10 from the number!", () => {
        //Arrange
        let number = -8.5;

        //Act
        let result = mathEnforcer.subtractTen(number);

        //Assert
        assert.closeTo(result, -18.5, 0.1);
    })

    it("Should sum the two numbers!", () => {
        //Arrange
        let number1 = 10;
        let number2 = 20;

        //Act
        let result = mathEnforcer.sum(number1, number2);

        //Assert
        assert.equal(result, 30);
    })

    it("Should sum the two numbers!", () => {
        //Arrange
        let number1 = 0;
        let number2 = 0;

        //Act
        let result = mathEnforcer.sum(number1, number2);

        //Assert
        assert.equal(result, 0);
    })

    it("Should sum the two numbers!", () => {
        //Arrange
        let number1 = 1;
        let number2 = 2;

        //Act
        let result = mathEnforcer.sum(number1, number2);

        //Assert
        assert.equal(result, 3);
    })

    it("Should sum the two numbers!", () => {
        //Arrange
        let number1 = -1;
        let number2 = -2;

        //Act
        let result = mathEnforcer.sum(number1, number2);

        //Assert
        assert.equal(result, -3);
    })

    it("Should sum the two numbers!", () => {
        //Arrange
        let number1 = 5.3;
        let number2 = 4.7;

        //Act
        let result = mathEnforcer.sum(number1, number2);

        //Assert
        assert.closeTo(result, 10, 0.1);
    })

    it("Should sum the two numbers!", () => {
        //Arrange
        let number1 = 5.3;
        let number2 = -4.2;

        //Act
        let result = mathEnforcer.sum(number1, number2);

        //Assert
        assert.closeTo(result, 1.1, 0.1);
    })
});