const { assert } = require('chai');
const { bookSelection } = require('./03-BookSelectionClass');

describe("Testing bookSelection obj and its methods!", () => {


    describe("Testing IsGanreSuitable method!", () => {

        it("Should return nonsuitable books", () => {

            //Arrange

            let answer1 = bookSelection.isGenreSuitable("Thriller", 12);
            let answer2 = bookSelection.isGenreSuitable("Horror", 11);
            let answer3 = bookSelection.isGenreSuitable("Thriller", 5);
            let answer4 = bookSelection.isGenreSuitable("Horror", 3);

            //Act and Assert

            assert.equal(answer1, `Books with Thriller genre are not suitable for kids at 12 age`);
            assert.equal(answer2, `Books with Horror genre are not suitable for kids at 11 age`);
            assert.equal(answer3, `Books with Thriller genre are not suitable for kids at 5 age`);
            assert.equal(answer4, `Books with Horror genre are not suitable for kids at 3 age`);
        });

        it("Should return suitable books", () => {

            //Arrange
            let answer1 = bookSelection.isGenreSuitable("Comedy", 5);
            let answer2 = bookSelection.isGenreSuitable("Comedy", 20);
            let answer3 = bookSelection.isGenreSuitable("Thriller", 20);
            let answer4 = bookSelection.isGenreSuitable("Thriller", 13);
            let answer5 = bookSelection.isGenreSuitable("Horror", 13);
            let answer6 = bookSelection.isGenreSuitable("Horror", 22);
            let answer7 = bookSelection.isGenreSuitable("Family", 45);
            let answer8 = bookSelection.isGenreSuitable("Romantic", 5);

            //Act and Assert

            assert.equal(answer1, `Those books are suitable`);
            assert.equal(answer2, `Those books are suitable`);
            assert.equal(answer3, `Those books are suitable`);
            assert.equal(answer4, `Those books are suitable`);
            assert.equal(answer5, `Those books are suitable`);
            assert.equal(answer6, `Those books are suitable`);
            assert.equal(answer7, `Those books are suitable`);
            assert.equal(answer8, `Those books are suitable`);
        });

    });


    describe("Testing isItAffordable method!", () => {
        it('Should throw Error with invalid input!', () => {

            assert.throw(() => { bookSelection.isItAffordable('pepi', 3); }, "Invalid input");
            assert.throw(() => { bookSelection.isItAffordable(3, 'pepi'); }, "Invalid input");
            assert.throw(() => { bookSelection.isItAffordable(true, false); }, "Invalid input");
            assert.throw(() => { bookSelection.isItAffordable({ price: 3 }, 3); }, "Invalid input");
            assert.throw(() => { bookSelection.isItAffordable(3, { price: 3 }); }, "Invalid input");
            assert.throw(() => { bookSelection.isItAffordable('false', 'true'); }, "Invalid input");
            assert.throw(() => { bookSelection.isItAffordable(true, 'true'); }, "Invalid input");
            assert.throw(() => { bookSelection.isItAffordable(false, 'false'); }, "Invalid input");
        });

        it('Should return that i bought the book!', () => {

            //Arrange
            let answer1 = bookSelection.isItAffordable(5, 10);
            let answer2 = bookSelection.isItAffordable(10, 10);
            let answer3 = bookSelection.isItAffordable(4, 50);
            let answer4 = bookSelection.isItAffordable(23, 24);
            let answer5 = bookSelection.isItAffordable(1, 2);

            //Act and Assert

            //test with negative
            assert.equal(answer1, `Book bought. You have 5$ left`);
            assert.equal(answer2, `Book bought. You have 0$ left`);
            assert.equal(answer3, `Book bought. You have 45$ left`);
            assert.equal(answer4, `Book bought. You have 1$ left`);
            assert.equal(answer5, `Book bought. You have 1$ left`);
        });

        it('Should return that i cannot buy the book!', () => {

            //Arrange
            let answer1 = bookSelection.isItAffordable(50, 10);
            let answer2 = bookSelection.isItAffordable(11, 10);
            let answer3 = bookSelection.isItAffordable(51, 50);
            let answer4 = bookSelection.isItAffordable(27, 24);
            let answer5 = bookSelection.isItAffordable(3, 2);

            //Act and Assert

            //test with negative
            assert.equal(answer1, "You don't have enough money");
            assert.equal(answer2, "You don't have enough money");
            assert.equal(answer3, "You don't have enough money");
            assert.equal(answer4, "You don't have enough money");
            assert.equal(answer5, "You don't have enough money");
        });
    });

    describe("Testing isItAffordable method!", () => {

        it("Should throw Error with invalid input!", () => {

            assert.throw(() => { bookSelection.suitableTitles("title", "title") }, "Invalid input");
            assert.throw(() => { bookSelection.suitableTitles({ name: 'title' }, 34) }, "Invalid input");
            assert.throw(() => { bookSelection.suitableTitles([2, 3, 4], 34) }, "Invalid input");
            assert.throw(() => { bookSelection.suitableTitles(34, 34) }, "Invalid input");
            assert.throw(() => { bookSelection.suitableTitles(true, "title") }, "Invalid input");
            assert.throw(() => { bookSelection.suitableTitles("title", true) }, "Invalid input");
            assert.throw(() => { bookSelection.suitableTitles(false, true) }, "Invalid input");
        });

        it("Should return valid array with book titles", () => {

            let resultArray1 = bookSelection.suitableTitles([{ title: "Avengers", genre: "Comedy" }, { title: "FridayNight", genre: "Horror" }, { title: "FastAndFurious", genre: "Action" }, { title: "Twinkies", genre: "Horror" }, { title: "jobless", genre: "Horror" }], 'Horror');
            assert.equal(resultArray1[0], "FridayNight");
            assert.equal(resultArray1[1], "Twinkies");
            assert.equal(resultArray1[2], "jobless");
        });

    });
})