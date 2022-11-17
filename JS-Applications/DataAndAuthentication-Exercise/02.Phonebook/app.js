function attachEvents() {

    let loadButton = document.getElementById('btnLoad');
    let createButton = document.getElementById('btnCreate');

    loadButton.addEventListener('click', loadContacts);
    createButton.addEventListener('click', createContact);

}

async function createContact() {
    let personElement = document.getElementById('person');
    let phoneNumberElement = document.getElementById('phone');

    // if (personElement.value == '' || phoneNumberElement == '') {
    //     return;
    // }

    let obj = {
        person: personElement.value,
        phone: phoneNumberElement.value
    }

    await postContact(obj);
    await loadContacts();

    personElement.value = '';
    phoneNumberElement.value = '';

}


async function postContact(obj) {
    let responce = await fetch('http://localhost:3030/jsonstore/phonebook', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(obj)
    });

    let data = responce.json();
    return data;
}


async function loadContacts() {

    let phonebook = document.getElementById('phonebook');
    phonebook.innerHTML = '';

    let contacts = await getContacts();

    for (let key in contacts) {
        let toAdd = document.createElement('li');
        toAdd.textContent = `${contacts[key].person}: ${contacts[key].phone}`;
        let deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';
        deleteButton.setAttribute('id', `${contacts[key]._id}`);
        deleteButton.addEventListener('click', deleteContact);
        toAdd.appendChild(deleteButton);
        phonebook.appendChild(toAdd);
    }
}

async function deleteContact(e) {
    let id = e.target.id;

    let responce = await fetch(`http://localhost:3030/jsonstore/phonebook/${id}`, {
        method: 'DELETE'
    });

    let data = await responce.json();
    return data;

}

async function getContacts() {
    let responce = await fetch('http://localhost:3030/jsonstore/phonebook');
    let data = await responce.json();
    return data;
}
attachEvents();