function sumTable() {
    let tableRows = document.querySelectorAll('table tr');
    let sum = 0;
    for (let index = 1; index < tableRows.length - 1; index++) {
        sum += Number(tableRows[index].querySelectorAll('td')[1].textContent);
    }

    let element = document.getElementById('sum');
    element.textContent = sum;
}