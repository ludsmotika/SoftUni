const { expect } = require('chai');
const { isOddOrEven } = require('./02-EvenOrOdd');


describe('Test isOddOrEven method', () => {
    it("Should return undefined with wrong type of input!", () => {
        //Arrange
        let stInput = { name: "Name" };
        let ndInput = true;
        let rdInput = 234;

        //Act
        let stResult = isOddOrEven(stInput);
        let ndResult = isOddOrEven(ndInput);
        let rdResult = isOddOrEven(rdInput);

        //Assert
        expect(stResult).to.be.equal(undefined);
        expect(ndResult).to.be.equal(undefined);
        expect(rdResult).to.be.equal(undefined);
    });

    it('Should return odd with string with odd length!', ()=>{
        //Arrange
        let text= 'lorem ipsum';

        //Act
        let result = isOddOrEven(text);

        //Assert
        expect(result).to.be.equal('odd');
    })

    
    it('Should return odd with string with odd length!', ()=>{
        //Arrange
        let text= 'x';

        //Act
        let result = isOddOrEven(text);

        //Assert
        expect(result).to.be.equal('odd');
    })

    it('Should return even with string with even length!', ()=>{
        //Arrange
        let text= 'loremipsum';

        //Act
        let result = isOddOrEven(text);

        //Assert
        expect(result).to.be.equal('even');
    })

    it('Should return even with string with even length!', ()=>{
        //Arrange
        let text= 'xx';

        //Act
        let result = isOddOrEven(text);

        //Assert
        expect(result).to.be.equal('even');
    })
});