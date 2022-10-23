class footballTeam {

    constructor(clubName, country) {
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = [];
    }

    newAdditions(footballPlayers) {

        let playerNames = [];
        for (let current of footballPlayers) {
            let playerinfo = current.split('/');

            //check for negative price
            if (playerinfo.length != 3 || isNaN(playerinfo[2]) || Number(playerinfo[2] <= 0) || isNaN(playerinfo[1]) || Number(playerinfo[1]) <= 0) {
                throw new Error('invalidInput!');
            }

            let currentName = playerinfo[0];
            let currentAge = Number(playerinfo[1]);
            let currentPrice = Number(playerinfo[2]);

            let player = this.invitedPlayers.find(x => x.name === currentName);
            if (player === undefined) {
                this.invitedPlayers.push({ name: currentName, age: currentAge, playerValue: currentPrice });
                playerNames.push(currentName);
            }
            else {
                if (player.playerValue < currentPrice) {
                    player.playerValue = currentPrice;
                }
            }
        }

        return `You successfully invite ${playerNames.join(', ')}.`;
    }

    signContract(selectedPlayer) {
        let selectedPlayerInfo = selectedPlayer.split('/');
        let playerName = selectedPlayerInfo[0];
        let playerOffer = Number(selectedPlayerInfo[1]);

        //validation for offer
        if (playerOffer <= 0) {
            throw new Error('invalidInput!');
        }

        let player = this.invitedPlayers.find(x => x.name === playerName);
        if (player === undefined) {
            throw new Error(`${playerName} is not invited to the selection list!`);
        }
        if (player.playerValue > playerOffer) {
            throw new Error(`The manager's offer is not enough to sign a contract with ${playerName}, ${player.playerValue - playerOffer} million more are needed to sign the contract!`);
        }

        player.playerValue = 'Bought';
        return `Congratulations! You sign a contract with ${playerName} for ${playerOffer} million dollars.`;
    }

    ageLimit(name, age) {

        let player = this.invitedPlayers.find(x => x.name === name);

        if (player === undefined) {
            throw new Error(`${name} is not invited to the selection list!`);
        }

        if (player.age >= age) {
            return `${name} is above age limit!`;
        }
        else {
            let ageDifference = Math.abs(age - player.age);
            if (ageDifference >= 5) {
                return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`;
            }
            else {
                return `${name} will sign a contract for ${ageDifference} years with ${this.clubName} in ${this.country}!`;
            }
        }
    }

    transferWindowResult() {
        let answer = "Players list:\n";
        for (let player of this.invitedPlayers.sort((a, b) => a.name.localeCompare(b.name))) {
            answer += `Player ${player.name}-${player.playerValue}\n`;
        }
        return answer.trim();
    }
}

let fTeam = new footballTeam("Barcelona", "Spain");
console.log(fTeam.newAdditions(["Kylian Mbappé/23/160", "Lionel Messi/35/50", "Pau Torres/25/52"]));
console.log(fTeam.ageLimit("Lionel Messi", 33));
console.log(fTeam.ageLimit("Kylian Mbappé", 30));
console.log(fTeam.ageLimit("Pau Torres", 30));
console.log(fTeam.signContract("Kylian Mbappé/200"));


