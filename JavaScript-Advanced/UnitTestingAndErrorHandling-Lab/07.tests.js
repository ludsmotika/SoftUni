const { expect } = require('chai');
const { createCalculator } = require('./07-AddSubtract');

describe('Test createCalculator method!', () => {
    it('should return object', () => {
        //arrange
        let calc = createCalculator();
        //assert
        expect(typeof (calc)).to.be.equal(typeof ({}));
    })

    it('returned obj should have certain functions', () => {
        //arrange
        let calc = createCalculator();
        let hasAddMethod = calc.hasOwnProperty('add');
        let hasSubtractMethod = calc.hasOwnProperty('subtract');
        let hasGetMethod = calc.hasOwnProperty('get');
        //assert
        expect(hasAddMethod).to.be.equal(true);
        expect(hasSubtractMethod).to.be.equal(true);
        expect(hasGetMethod).to.be.equal(true);
    })

    it('add method should modify the result', () => {
        //arrange
        let calc = createCalculator();

        //act
        calc.add(4);
        let result = calc.get();

        //assert
        expect(result).to.be.equal(4);
    })

    it('add method should modify the result', () => {
        //arrange
        let calc = createCalculator();

        //act
        calc.add(4);
        calc.add(5);
        let result = calc.get();

        //assert
        expect(result).to.be.equal(9);
    })

    it('subtract method should modify the result', () => {
        //arrange
        let calc = createCalculator();

        //act
        calc.subtract(4);
        let result = calc.get();

        //assert
        expect(result).to.be.equal(-4);
    })

    it('subtract method should modify the result', () => {
        //arrange
        let calc = createCalculator();

        //act
        calc.subtract(4);
        calc.subtract(5);
        let result = calc.get();

        //assert
        expect(result).to.be.equal(-9);
    })

    it('both methods should work properly!', () => {
        //arrange
        let calc = createCalculator();

        //act
        calc.add(5);
        calc.subtract(5);
        let result = calc.get();

        //assert
        expect(result).to.be.equal(0);
    })


    it('both methods should work properly with string input!', () => {
        //arrange
        let calc = createCalculator();

        //act
        calc.add('2');
        calc.subtract('3');
        let result = calc.get();

        //assert
        expect(result).to.be.equal(-1);
    })


    it('add method should work properly with string input!', () => {
        //arrange
        let calc = createCalculator();

        //act
        calc.add('2');
        let result = calc.get();

        //assert
        expect(result).to.be.equal(2);
    })
    it('subtract method should work properly with string!', () => {
        //arrange
        let calc = createCalculator();

        //act
        calc.subtract('2');
        let result = calc.get();

        //assert
        expect(result).to.be.equal(-2);
    })

});