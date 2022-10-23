function deleteByEmail() {
    let inputElement=document.getElementsByName('email')[0];
    let tableElement= document.querySelectorAll('#customers tbody tr');
let resultElement=document.getElementById('result');

    let found=false;
    for (let row  of tableElement) {
        let currentEmail= row.querySelectorAll('td')[1].textContent;
        if (currentEmail===inputElement.value) {
            row.remove();
            found=true;
        }
    }
    inputElement.value='';
    resultElement.textContent=found? 'Deleted.':'Not found.'
}