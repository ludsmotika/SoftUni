function addItem() {
    let inputElement = document.getElementById('newItemText').value;
    let list = document.getElementById('items');

    let elementToAdd= document.createElement('li');
    
    elementToAdd.textContent=inputElement;
    list.appendChild(elementToAdd);

    document.getElementById('newItemText').value='';
}