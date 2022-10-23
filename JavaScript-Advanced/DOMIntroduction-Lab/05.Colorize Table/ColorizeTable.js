function colorize() {
    let tableRows = document.querySelectorAll('table tr')
    for (let index = 1; index < tableRows.length; index++) {
        if (index % 2 != 0) {
                tableRows[index].style.backgroundColor = 'teal';
        }
    }
}