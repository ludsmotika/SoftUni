class Garden {

    constructor(spaceAvailable) {
        this.spaceAvailable = spaceAvailable;
        this.plants = [];
        this.storage = [];
    }

    addPlant(plantName, spaceRequired) {

        if (spaceRequired > this.spaceAvailable) {
            throw new Error("Not enough space in the garden.");
        }

        let currentPlant = {
            plantName,
            spaceRequired,
            ripe: false,
            quantity: 0
        };

        this.spaceAvailable -= spaceRequired;
        this.plants.push(currentPlant);
        return `The ${plantName} has been successfully planted in the garden.`;
    }

    ripenPlant(plantName, quantity) {

        let currentPlant = this.plants.find(x => x.plantName == plantName);

        if (currentPlant === undefined) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if (currentPlant.ripe === true) {
            throw new Error(`The ${plantName} is already ripe.`);
        }

        if (quantity <= 0) {
            throw new Error(`The quantity cannot be zero or negative.`);
        }

        currentPlant.ripe = true;
        currentPlant.quantity += quantity;

        if (quantity === 1) {
            return `${quantity} ${plantName} has successfully ripened.`;
        }
        else {
            return `${quantity} ${plantName}s have successfully ripened.`;
        }

    }

    harvestPlant(plantName) {

        let currentPlant = this.plants.find(x => x.plantName == plantName);

        if (currentPlant === undefined) {
            throw new Error(`There is no ${plantName} in the garden.`);
        }

        if (currentPlant.ripe === false) {
            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`);
        }

        let storageInfoObj = {
            plantName,
            quantity: currentPlant.quantity
        };

        this.storage.push(storageInfoObj);
        this.spaceAvailable += currentPlant.spaceRequired;

        let indexOfPlant = this.plants.indexOf(currentPlant);
        this.plants.splice(indexOfPlant, 1);

        return `The ${plantName} has been successfully harvested.`;
    }

    generateReport() {
        let answer = '';
        answer += `The garden has ${this.spaceAvailable} free space left.\n`;
        answer += `Plants in the garden: ${this.plants.map(x => x.plantName).join(', ')}\n`;

        if (this.storage.length === 0) {
            answer += `Plants in storage: The storage is empty.`;
        }
        else {
            answer += "Plants in storage: ";
            for (let index = 0; index < this.storage.length - 1; index++) {
                answer += `${this.storage[index].plantName} (${this.storage[index].quantity}), `;
            }
            answer += `${this.storage[this.storage.length - 1].plantName} (${this.storage[this.storage.length - 1].quantity})`;
        }

        return answer;
    }
}
