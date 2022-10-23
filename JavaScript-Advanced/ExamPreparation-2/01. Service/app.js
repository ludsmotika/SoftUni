window.addEventListener("load", solve);

function solve() {

    let sendFormButton = document.querySelector("#right button");
    let receivedOrdersElement = document.getElementById('received-orders');
    let completedOrdersElement = document.getElementById('completed-orders');
    let clearButton = document.getElementById('completed-orders').children[2];
    let typeOfProductElement = document.getElementById("type-product");
    let descriptionElement = document.getElementById("description");
    let clientNameElement = document.getElementById("client-name");
    let clientPhoneElement = document.getElementById("client-phone");

    sendFormButton.addEventListener('click', sendForm);
    clearButton.addEventListener('click', clear);

    function sendForm(e) {

        e.preventDefault();

        if (descriptionElement.value === "" || clientNameElement.value == '' || clientPhoneElement.value == '') {
            return;
        }

        let elementToAdd = document.createElement('div');
        elementToAdd.classList.add('container');

        let h2Element = document.createElement('h2');
        h2Element.textContent = `Product type for repair: ${typeOfProductElement.value}`;
        let h3Element = document.createElement('h3');
        h3Element.textContent = `Client information: ${clientNameElement.value}, ${clientPhoneElement.value}`;
        let h4Element = document.createElement('h4');
        h4Element.textContent = `Description of the problem: ${descriptionElement.value}`;

        let startRepairButton = document.createElement('button');
        startRepairButton.textContent = 'Start Repair';
        startRepairButton.classList.add('start-btn');
        startRepairButton.addEventListener('click', startRepair);

        let finishRepairButton = document.createElement('button');
        finishRepairButton.textContent = 'Finish Repair';
        finishRepairButton.classList.add('finish-btn');
        finishRepairButton.disabled = true;
        finishRepairButton.addEventListener('click', finishRepair);

        elementToAdd.appendChild(h2Element);
        elementToAdd.appendChild(h3Element);
        elementToAdd.appendChild(h4Element);
        elementToAdd.appendChild(startRepairButton);
        elementToAdd.appendChild(finishRepairButton);

        receivedOrdersElement.appendChild(elementToAdd);

        descriptionElement.value = '';
        clientNameElement.value = '';
        clientPhoneElement.value = '';

    }

    function startRepair(e) {
        let finishButton = e.target.parentElement.querySelectorAll('button')[1];
        e.target.disabled = true;
        finishButton.disabled = false;
    }

    function finishRepair(e) {
        let elementToAdd = document.createElement('div');
        let parentElement = e.target.parentElement;
        elementToAdd.classList.add('container');

        let h2Element = document.createElement('h2');
        h2Element.textContent = `${parentElement.children[0].textContent}`;
        let h3Element = document.createElement('h3');
        h3Element.textContent = `${parentElement.children[1].textContent}`;
        let h4Element = document.createElement('h4');
        h4Element.textContent = `${parentElement.children[2].textContent}`;


        elementToAdd.appendChild(h2Element);
        elementToAdd.appendChild(h3Element);
        elementToAdd.appendChild(h4Element);


        completedOrdersElement.appendChild(elementToAdd);
        e.target.parentElement.remove();
    }

    function clear(e) {
        let array = e.target.parentElement.querySelectorAll('div');
        for (let element of array) {
            element.remove();
        }
    }
}