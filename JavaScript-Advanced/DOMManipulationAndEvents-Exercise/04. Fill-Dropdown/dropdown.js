function addItem() {
    let inputText=document.getElementById('newItemText');
    let inputValue=document.getElementById('newItemValue');
    let dropdownMenu=document.getElementById('menu');
    
    let elementToAdd= document.createElement('option');
    elementToAdd.textContent =inputText.value;
    elementToAdd.value=inputValue.value;

    dropdownMenu.appendChild(elementToAdd);
    inputText.value='';
    inputValue.value='';
}