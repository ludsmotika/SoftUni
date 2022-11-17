attachEvents();

function attachEvents() {
    let loadButton = document.getElementById('loadBooks');
    loadButton.addEventListener('click', loadBooks);
    document.getElementById('submitButton').addEventListener('click', submitBook);
}

async function submitBook(e) {
    e.preventDefault();
    let bookObj = { title: `${document.getElementById('titleInput').value}`, author: `${document.getElementById('authorInput').value}` }

    if (bookObj.author == '' || bookObj.title == '') {
        alert('invalid input');
        return;
    }

    let responce = await postBook(bookObj);

    let inputFields = document.querySelectorAll('input');
    inputFields[0].value = '';
    inputFields[1].value = '';

    return responce;
}

async function postBook(bookObj) {
    let responce = await fetch('http://localhost:3030/jsonstore/collections/books', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(bookObj)
    });
    let answer = await responce.json();

    await loadBooks();

    return responce;
}

async function loadBooks() {
    let outputElement = document.querySelector('tbody');
    outputElement.innerHTML = '';

    let books = await getBooks();

    for (let current in books) {
        let tr = document.createElement('tr');
        let firstTd = document.createElement('td');
        firstTd.textContent = books[current].title;

        let secondTd = document.createElement('td');
        secondTd.textContent = books[current].author;

        let thirdTd = document.createElement('td');
        let editButton = document.createElement('button');
        editButton.textContent = 'Edit';
        editButton.setAttribute('bookid', current);
        editButton.setAttribute('id', current);
        editButton.addEventListener('click', editBook);

        let deleteButton = document.createElement('button');
        deleteButton.textContent = 'Delete';
        deleteButton.setAttribute('bookid', current);
        deleteButton.addEventListener('click', deleteBook);

        thirdTd.appendChild(editButton);
        thirdTd.appendChild(deleteButton);

        tr.appendChild(firstTd);
        tr.appendChild(secondTd);
        tr.appendChild(thirdTd);

        outputElement.appendChild(tr);
    }
}

async function editBook(e) {
    e.preventDefault();
    document.getElementById(`${e.target.attributes.bookid.nodeValue}`).disabled = true;
    document.getElementById('form-text').textContent = 'Edit FORM';
    document.getElementById('submitButton').style.display = 'none';

    let book = await getBookById(e.target.attributes.bookid.nodeValue);
    document.getElementById('titleInput').value = book.title;
    document.getElementById('authorInput').value = book.author;


    let newButton = document.createElement('button');
    newButton.setAttribute('bookid', `${e.target.attributes.bookid.nodeValue}`);
    newButton.addEventListener('click', async (e) => {
        e.preventDefault();

        let res = await fetch(`http://localhost:3030/jsonstore/collections/books/${e.target.attributes.bookid.nodeValue}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ title: `${document.getElementById('titleInput').value}`, author: `${document.getElementById('authorInput').value}` })
        })

        let answer = await res.json();

        restoreForm();
        await loadBooks();
        return answer;
    });


    newButton.textContent = 'Save';
    document.getElementById('form').appendChild(newButton);

}

function restoreForm() {
    document.getElementById('form-text').textContent = 'FORM';
    document.getElementById('submitButton').style.display = 'block';

    let inputFields = document.querySelectorAll('input');
    inputFields[0].value = '';
    inputFields[1].value = '';

    document.getElementById('form').children[6].remove();
}

async function getBookById(bookId) {
    let responce = await fetch(`http://localhost:3030/jsonstore/collections/books/${bookId}`);
    let book = await responce.json();
    return book;
}

async function deleteBook(e) {
    e.preventDefault();
    let responce = await fetch(`http://localhost:3030/jsonstore/collections/books/${e.target.attributes.bookid.nodeValue}`, {
        method: 'DELETE'
    });
    let answer = await responce.json();

    await loadBooks();

    return answer;
}
async function getBooks() {
    let res = await fetch('http://localhost:3030/jsonstore/collections/books');
    let data = await res.json();
    return data;
}