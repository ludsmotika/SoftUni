const { assert } = require('chai');
const { lookupChar } = require('./03-CharLookup');


describe("Tests for the lookupChar method", () => {

    it('Should return undefined with wrong type of input!', () => {
        //Arrange
        let inputText1 = 'loremipsum';
        let inputIndex1 = true;

        let inputText2 = true;
        let inputIndex2 = 3;

        let inputText3 = { name: 'loremipsum' };
        let inputIndex3 = 4;

        let inputText4 = 5;
        let inputIndex4 = 'loremipsum';

        let inputText5 = 'loremipsum';
        let inputIndex5 = 5.34;

        let inputText6 = 'loremipsum';
        let inputIndex6 = { name: 'loremipsum' };

        //Act
        let result1 = lookupChar(inputText1, inputIndex1);
        let result2 = lookupChar(inputText2, inputIndex2);
        let result3 = lookupChar(inputText3, inputIndex3);
        let result4 = lookupChar(inputText4, inputIndex4);
        let result5 = lookupChar(inputText5, inputIndex5);
        let result6 = lookupChar(inputText6, inputIndex6);

        //Assert
        assert.equal(result1, undefined);
        assert.equal(result2, undefined);
        assert.equal(result3, undefined);
        assert.equal(result4, undefined);
        assert.equal(result5, undefined);
        assert.equal(result6, undefined);
    });

    it("Should return 'Incorrect index' with index which is out of range", () => {
        //Arrange
        let text = 'loremipsum';
        let index = -1;

        //Act
        let result = lookupChar(text, index);

        //Assert
        assert.equal(result, 'Incorrect index');
    })

    it("Should return 'Incorrect index' with index which is out of range", () => {
        //Arrange
        let text = 'loremipsum';
        let index = 10;

        //Act
        let result = lookupChar(text, index);

        //Assert
        assert.equal(result, 'Incorrect index');
    })

    it("Should return the char at a given index!", () => {
        //Arrange
        let text = 'loremipsum';
        let index = 0;

        //Act
        let result = lookupChar(text, index);

        //Assert
        assert.equal(result, 'l');
    })

    it("Should return the char at a given index!", () => {
        //Arrange
        let text = 'loremipsum';
        let index = 9;

        //Act
        let result = lookupChar(text, index);

        //Assert
        assert.equal(result, 'm');
    })

    it("Should return the char at a given index!", () => {
        //Arrange
        let text = 'loremipsum';
        let index = 4;

        //Act
        let result = lookupChar(text, index);

        //Assert
        assert.equal(result, 'm');
    })
});