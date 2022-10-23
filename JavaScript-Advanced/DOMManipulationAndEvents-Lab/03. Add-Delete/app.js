function addItem() {
    let inputElement = document.getElementById('newItemText').value;
    let list = document.getElementById('items');

    let elementToAdd = document.createElement('li');

    let deleteButton = document.createElement('a');
    deleteButton.textContent = '[Delete]';
    deleteButton.href = "#";

    deleteButton.addEventListener('click', (event) => {
        event.target.parentElement.remove();
    })

    elementToAdd.textContent = inputElement;
    elementToAdd.appendChild(deleteButton);

    list.appendChild(elementToAdd);

    document.getElementById('newItemText').value = '';
}