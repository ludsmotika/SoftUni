function solve() {
    let inputRecipientNameElement = document.getElementById('recipientName');
    let inputTitleElement = document.getElementById('title');
    let inputMessageElement = document.getElementById('message');
    let addButton = document.getElementById('add');
    let resetButton = document.getElementById('reset');
    let listWithMail = document.getElementById('list');
    let sentList = document.getElementsByClassName('sent-list')[0];
    let deleteList = document.getElementsByClassName('delete-list')[0];
    addButton.addEventListener('click', addToTheList);
    resetButton.addEventListener('click', clearInput);

    function addToTheList(e) {
        e.preventDefault();
        let currentReceiptName = inputRecipientNameElement.value;
        let currentTitle = inputTitleElement.value;
        let currentMessage = inputMessageElement.value;

        if (currentReceiptName === '' || currentTitle === '' || currentMessage === '') {
            return;
        }
        let toAdd = document.createElement('li');

        let title = document.createElement('h4');
        let recipientName = document.createElement('h4');
        let message = document.createElement('span');
        let buttons = document.createElement('div');

        buttons.setAttribute('id', 'list-action');

        let firstButton = document.createElement('button');
        firstButton.setAttribute('type', 'submit');
        firstButton.setAttribute('id', 'send');
        firstButton.textContent = 'Send';
        firstButton.addEventListener('click', send);

        let secondButton = document.createElement('button');
        secondButton.setAttribute('type', 'submit');
        secondButton.setAttribute('id', 'delete');
        secondButton.textContent = 'Delete';
        secondButton.addEventListener('click', deleteMail);

        buttons.appendChild(firstButton);
        buttons.appendChild(secondButton);

        title.textContent = `Title: ${currentTitle}`;
        recipientName.textContent = `Recipient Name: ${currentReceiptName}`;
        message.textContent = `${currentMessage}`;

        toAdd.appendChild(title);
        toAdd.appendChild(recipientName);
        toAdd.appendChild(message);
        toAdd.appendChild(buttons);

        listWithMail.appendChild(toAdd);


        inputMessageElement.value = '';
        inputRecipientNameElement.value = '';
        inputTitleElement.value = '';
    };

    function clearInput(e) {
        e.preventDefault();
        inputTitleElement.value = '';
        inputMessageElement.value = '';
        inputRecipientNameElement.value = '';
    }

    function send(e) {

        let currentMail = e.target.parentElement.parentElement;
        let toAdd = document.createElement('li');
        let receiver = document.createElement('span');
        let title = document.createElement('span');
        let buttons = document.createElement('div');
        buttons.setAttribute('class', 'btn');

        receiver.textContent = `To: ${currentMail.children[1].textContent.split('Recipient Name: ')[1]}`;
        title.textContent = `${currentMail.children[0].textContent}`;

        let deleteButton = document.createElement('button');
        deleteButton.setAttribute('type', 'submit');
        deleteButton.setAttribute('class', 'delete');
        deleteButton.textContent = 'Delete';
        deleteButton.addEventListener('click', deleteMail);

        buttons.appendChild(deleteButton);

        toAdd.appendChild(receiver);
        toAdd.appendChild(title);
        toAdd.appendChild(buttons);

        sentList.appendChild(toAdd);

        currentMail.remove();
    }




    function deleteMail(e) {

        let currentMail = e.target.parentElement.parentElement;
        let toAdd = document.createElement('li');
        let receiver = document.createElement('span');
        let title = document.createElement('span');


        if (currentMail.children.length === 3) {
            receiver.textContent = currentMail.children[0].textContent;
            title.textContent = currentMail.children[1].textContent;
        }
        else {
            receiver.textContent = `To: ${currentMail.children[1].textContent.split('Recipient Name: ')[1]}`;
            title.textContent = `${currentMail.children[0].textContent}`;
        }

        toAdd.appendChild(receiver);
        toAdd.appendChild(title);

        deleteList.appendChild(toAdd);

        currentMail.remove();
    }

}
solve()