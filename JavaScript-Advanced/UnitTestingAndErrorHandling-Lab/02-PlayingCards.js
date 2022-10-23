function getCard(face, suit) {
    let validSuits = ['S', 'H', 'D', 'C'];
let validFaces=['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

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

console.log(getCard('5', 'S').toString());