const { expect } = require('chai');
const { sum } = require('./04-SumofNumbers.js');

describe('Sum Method', () => {
    it('should return right answer', () => {
        //arrange
        let arr = [1, 2, 3, 4, 5];

        //act
        let result = sum(arr);

        //assert
        expect(result).to.be.equal(15);
    })
    it('should return right answer', () => {
        //arrange
        let arr = [1, 2, 3, 4, 5, 6];

        //act
        let result = sum(arr);

        //assert
        expect(result).to.be.equal(21);
    })
    it('should return right answer', () => {
        //arrange
        let arr = [1, 2, 3, 4, 5, -3];

        //act
        let result = sum(arr);

        //assert
        expect(result).to.be.equal(12);
    })

})