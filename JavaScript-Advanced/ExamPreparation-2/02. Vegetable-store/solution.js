class VegetableStore {

    constructor(owner, location) {
        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
    }

    loadingVegetables(vegetables) {

        let addedVegetables = [];

        for (let current of vegetables) {
            let [currentType, currentQuantity, currentPrice] = current.split(' ');

            let indexOfProduct = this.availableProducts.findIndex(x => x.type === currentType);
            if (indexOfProduct === -1) {

                this.availableProducts.push({
                    type: currentType,
                    quantity: Number(currentQuantity),
                    price: Number(currentPrice)
                });

                addedVegetables.push(currentType);

            }
            else {
                this.availableProducts[indexOfProduct].quantity += Number(currentQuantity)
                if (this.availableProducts[indexOfProduct].price < Number(currentPrice)) {
                    this.availableProducts[indexOfProduct].price = Number(currentPrice);
                }
            }
        }

        return `Successfully added ${addedVegetables.join(', ')}`;
    }

    buyingVegetables(selectedProducts) {

        let totalPrice = 0;

        for (let current of selectedProducts) {
            let [currentType, currentQuantity] = current.split(' ');
            let indexOfProduct = this.availableProducts.findIndex(x => x.type == currentType);

            if (indexOfProduct === -1) {
                throw new Error(`${currentType} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
            }
            else {
                if (this.availableProducts[indexOfProduct].quantity < currentQuantity) {
                    throw new Error(`The quantity ${currentQuantity} for the vegetable ${currentType} is not available in the store, your current bill is $${totalPrice.toFixed(2)}.`);
                }
                else {
                    totalPrice += this.availableProducts[indexOfProduct].price * currentQuantity;
                    this.availableProducts[indexOfProduct].quantity -= currentQuantity;
                }
            }
        }

        return `Great choice! You must pay the following amount $${totalPrice.toFixed(2)}.`;
    }

    rottingVegetable(type, quantity) {

        let indexOfProduct = this.availableProducts.findIndex(x => x.type == type);

        if (indexOfProduct === -1) {
            throw new Error(`${type} is not available in the store.`);
        }
        else {
            if (quantity > this.availableProducts[indexOfProduct].quantity) {
                this.availableProducts[indexOfProduct].quantity = 0;
                return `The entire quantity of the ${type} has been removed.`;
            }
            else {
                this.availableProducts[indexOfProduct].quantity -= quantity;
                return `Some quantity of the ${type} has been removed.`;
            }
        }

    }

    revision() {
        let answer = '';
        answer += "Available vegetables:\n";

        for (let current of this.availableProducts.sort((a, b) => { return a.price - b.price })) {
            answer += `${current.type}-${current.quantity}-$${current.price}\n`;
        }

        answer += `The owner of the store is ${this.owner}, and the location is ${this.location}.`;
        return answer;
    }

}


let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
console.log(vegStore.rottingVegetable("Okra", 1));
console.log(vegStore.rottingVegetable("Okra", 2.5));
console.log(vegStore.buyingVegetables(["Beans 8", "Celery 1.5"]));
console.log(vegStore.revision());
