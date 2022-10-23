const {expect} = require('chai');
const {isSymmetric} =require('./05-CheckForSymmetry');

describe('IsSymmetric Method', ()=>{
    
    it('Takes array as argument', () => {
        let input1 = 1;
        let input2 = {};
        let input3 = 'someText';
        let input4 = null;
        let input5 = [true, false, true, false, false];
        let input6 = false;
        let input7 = undefined;
        let input8 = [true, 'text'];

        expect(isSymmetric(input1)).to.be.equal(false);
        expect(isSymmetric(input2)).to.be.equal(false);
        expect(isSymmetric(input3)).to.be.equal(false);
        expect(isSymmetric(input4)).to.be.equal(false);
        expect(isSymmetric(input5)).to.be.equal(false);
        expect(isSymmetric(input6)).to.be.equal(false);
        expect(isSymmetric(input7)).to.be.equal(false);
        expect(isSymmetric(input8)).to.be.equal(false);
    });
    
    it("Should return true with symmetric array!", ()=>{
        //Arrange
        let arr= [1,2,2,1];

        //Act
        let result = isSymmetric(arr);

        //Assert
        expect(result).to.be.equal(true);
    })

    it("Should return true with symmetric array!", ()=>{
        //Arrange
        let arr= [1,2,3,4,5,4,3,2,1];

        //Act
        let result = isSymmetric(arr);

        //Assert
        expect(result).to.be.equal(true);
    })

    it("Should return true with empty array!", ()=>{
        //Arrange
        let arr= [];

        //Act
        let result = isSymmetric(arr);

        //Assert
        expect(result).to.be.equal(true);
    })

    it("Should return true with mixed symmetric array!", ()=>{
        //Arrange
        let arr= [2,'dani',2];

        //Act
        let result = isSymmetric(arr);

        //Assert
        expect(result).to.be.equal(true);
    })

    it("Should return true with mixed symmetric array!", ()=>{
        //Arrange
        let arr= [2,'dani','dani',2];

        //Act
        let result = isSymmetric(arr);

        //Assert
        expect(result).to.be.equal(true);
    })

    it("Should return false with mixed assymmetric array!", ()=>{
        //Arrange
        let arr= [2,'dani',2,'daniel4o'];

        //Act
        let result = isSymmetric(arr);

        //Assert
        expect(result).to.be.equal(false);
    })

    it("Should return false with mixed assymmetric array!", ()=>{
        //Arrange
        let arr= [2,'dani',true];

        //Act
        let result = isSymmetric(arr);

        //Assert
        expect(result).to.be.equal(false);
    })
    
    it("Should return false with assymmetric array!", ()=>{
        //Arrange
        let arr= [1,2,3,4,5];

        //Act
        let result = isSymmetric(arr);

        //Assert
        expect(result).to.be.equal(false);
    })

    it("Should return false with assymmetric array!", ()=>{
        //Arrange
        let arr= [1,2,3,4];

        //Act
        let result = isSymmetric(arr);

        //Assert
        expect(result).to.be.equal(false);
    })

    it("Should return false with assymmetric array!", ()=>{
        //Arrange
        let arr= [1,2];

        //Act
        let result = isSymmetric(arr);

        //Assert
        expect(result).to.be.equal(false);
    })
    
    it("Should return false with invalid input!", ()=>{
        //Arrange
        let arr= 'Invalid input';

        //Act
        let result=isSymmetric(arr);

        //Act & Assert
        expect(result).to.be.equal(false);
    })

    it("Should return false with invalid input!", ()=>{
        //Arrange
        let arr= 4;

        //Act
        let result=isSymmetric(arr);

        //Act & Assert
        expect(result).to.be.equal(false);
    })
})