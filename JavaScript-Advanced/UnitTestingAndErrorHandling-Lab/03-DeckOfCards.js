function printDeckOfCards(cards) {
    let validSuits = ['S', 'H', 'D', 'C'];
    let validFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    let result = [];

    for (let card of cards) {
        try {
            let currentCard = createCard(card.slice(0, card.length - 1), card[card.length - 1]);
            result.push(currentCard);
        } catch (error) {
            console.log(`Invalid card: ${card}`);
            return;
        }
    }

    console.log(result.join(' '));




    function createCard(face, suit) {

        if (validSuits.indexOf(suit) === -1) {
            throw new Error('The card has invalid suit!');
        }

        if (validFaces.indexOf(face) === -1) {
            throw new Error('The card has invalid suit!');
        }

        let suitUTF = '';
        switch (suit) {
            case 'S': suitUTF = '\u2660'; break;
            case 'H': suitUTF = '\u2665'; break;
            case 'D': suitUTF = '\u2666'; break;
            case 'C': suitUTF = '\u2663'; break;
        }

        return {
            face,
            suitUTF,
            toString: () => { return face + suitUTF; }
        };
    }
}

printDeckOfCards(['5S', '3D', 'QD', '1C']);