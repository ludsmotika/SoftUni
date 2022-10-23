const { expect } = require('chai');
const { rgbToHexColor } = require('./06-RGBtoHex');

describe('rgbToHex', () => {
    it('should not work with invalid input', () => {
        //Arrange
        let red = 'invalid';
        let green = 0;
        let blue = 0;

        //Act
        let result = rgbToHexColor(red, green, blue);

        //Assert
        expect(result).to.be.equal(undefined);
    })
    it('should not work with invalid input', () => {
        //Arrange
        let red = 0;
        let green = 'invalid';
        let blue = 0;

        //Act
        let result = rgbToHexColor(red, green, blue);

        //Assert
        expect(result).to.be.equal(undefined);
    })
    it
    ('should not work with invalid input', () => {
        //Arrange
        let red = 0;
        let green = 0;
        let blue = 'invalid';
        
        //Act
        let result = rgbToHexColor(red, green, blue);
        
        //Assert
        expect(result).to.be.equal(undefined);
    })
    it('should not work with invalid input', () => {
        //Arrange
        let red = true;
        let green = 0;
        let blue = 0;

        //Act
        let result = rgbToHexColor(red, green, blue);

        //Assert
        expect(result).to.be.equal(undefined);
    })
    it('should not work with invalid input', () => {
        //Arrange
        let red = 0;
        let green = true;
        let blue = 0;

        //Act
        let result = rgbToHexColor(red, green, blue);

        //Assert
        expect(result).to.be.equal(undefined);
    })
    it('should not work with invalid input', () => {
        //Arrange
        let red = 0;
        let green = 0;
        let blue = true;

        //Act
        let result = rgbToHexColor(red, green, blue);

        //Assert
        expect(result).to.be.equal(undefined);
    })
    it('should work with valid input', () => {
        //Arrange
        let red = 0;
        let green = 0;
        let blue = 0;

        //Act
        let result = rgbToHexColor(red, green, blue);

        //Assert
        expect(result).not.to.be.equal(undefined);
    })
    it('should work with valid input', () => {
        //Arrange
        let red = 255;
        let green = 255;
        let blue = 255;

        //Act
        let result = rgbToHexColor(red, green, blue);

        //Assert
        expect(result).not.to.be.equal(undefined);
    })
    it('should work with valid input', () => {
        //Arrange
        let red = 10;
        let green = 20;
        let blue = 30;

        //Act
        let result = rgbToHexColor(red, green, blue);

        //Assert
        expect(result).not.to.be.equal(undefined);
    })

    it('should return undefined with invalid input', () => {
        //Arrange
        let red = 300;
        let green = 10;
        let blue = 10;

        //Act
        let result = rgbToHexColor(red, green, blue);

        //Assert
        expect(result).to.be.equal(undefined);
    })
    it('should return undefined with invalid input', () => {
        //Arrange
        let red = 10;
        let green = 300;
        let blue = 10;

        //Act
        let result = rgbToHexColor(red, green, blue);

        //Assert
        expect(result).to.be.equal(undefined);
    })
    it('should return undefined with invalid input', () => {
        //Arrange
        let red = 10;
        let green = 10;
        let blue = 300;

        //Act
        let result = rgbToHexColor(red, green, blue);

        //Assert
        expect(result).to.be.equal(undefined);
    })
    it('should return undefined with invalid input', () => {
        //Arrange
        let red = -1;
        let green = 10;
        let blue = 10;

        //Act
        let result = rgbToHexColor(red, green, blue);

        //Assert
        expect(result).to.be.equal(undefined);
    })
    it('should return undefined with invalid input', () => {
        //Arrange
        let red = 10;
        let green =-1;
        let blue = 10;

        //Act
        let result = rgbToHexColor(red, green, blue);

        //Assert
        expect(result).to.be.equal(undefined);
    })
    it('should return undefined with invalid input', () => {
        //Arrange
        let red = 10;
        let green = 10;
        let blue = -1;

        //Act
        let result = rgbToHexColor(red, green, blue);

        //Assert
        expect(result).to.be.equal(undefined);
    })

    it('should return correct hex with valid input', () => {
        //Arrange
        let red = 0;
        let green = 0;
        let blue = 0;

        //Act
        let result = rgbToHexColor(red, green, blue);

        //Assert
        expect(result).to.be.equal('#000000');
    })

    it('should return correct hex with valid input', () => {
        //Arrange
        let red = 255;
        let green = 255;
        let blue = 255;

        //Act
        let result = rgbToHexColor(red, green, blue);

        //Assert
        expect(result).to.be.equal('#FFFFFF');
    })

    it('should return correct hex with valid input', () => {
        //Arrange
        let red = 10;
        let green = 20;
        let blue = 30;

        //Act
        let result = rgbToHexColor(red, green, blue);

        //Assert
        expect(result).to.be.equal('#0A141E');
    })

    it('should return correct hex with valid input', () => {
        //Arrange
        let red = 255;
        let green = 0;
        let blue = 0;

        //Act
        let result = rgbToHexColor(red, green, blue);

        //Assert
        expect(result).to.be.equal('#FF0000');
    })

    it('should return correct hex with valid input', () => {
        //Arrange
        let red = 254;
        let green = 0;
        let blue = 0;

        //Act
        let result = rgbToHexColor(red, green, blue);

        //Assert
        expect(result).not.to.be.equal('#FF0000');
    })

    
})