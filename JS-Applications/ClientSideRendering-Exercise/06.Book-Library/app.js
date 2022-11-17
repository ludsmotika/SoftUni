import { html, render, nothing } from '../node_modules/lit-html/lit-html.js';
import { get, post, put, del } from './api.js';
import { showTable, showAddMenu, showEditMenu } from './htmlRenders.js';

let tBodyElement = document.querySelector('tbody');
let submitForm = document.getElementById('currentForm');
document.getElementById('loadBooks').addEventListener('click', loadBooks);

render(showAddMenu(), submitForm);

async function loadBooks(e) {

    if (e) {
        e.preventDefault();
    }

    let data = await get('/jsonstore/collections/books');

    let dataList = [];
    for (let key in data) {
        dataList.push({ title: data[key].title, author: data[key].author, id: key });
    }

    render(dataList.map(showTable), tBodyElement);

}


export async function addRow(e) {
    e.preventDefault();
    let form = new FormData(document.getElementById('currentForm'));
    let data = Object.fromEntries(form);

    if (data.title == '' || data.author == '') {
        return;
    }

    await post('/jsonstore/collections/books', data);

    document.getElementById('titleInput').value = '';
    document.getElementById('authorInput').value = '';

    loadBooks();
}

export async function showEditPage(e) {

    e.preventDefault();

    let book = await get(`/jsonstore/collections/books/${e.target.id}`);

    render(showEditMenu(book), submitForm);

}

export async function updateRow(e, row) {
    e.preventDefault();

    let form = new FormData(document.getElementById('currentForm'));
    let data = Object.fromEntries(form);
    let id = e.target.id;

    let newData = { title: data.title, author: data.author };

    console.log(data);

    await put(`/jsonstore/collections/books/${id}`, newData);



    document.getElementById('titleInput').value = '';
    document.getElementById('authorInput').value = '';

    render(showAddMenu(), submitForm);
    loadBooks();

}

export async function deleteRow(e) {
    let id = e.target.id;
    console.log(e.target);
    await del(`/jsonstore/collections/books/${id}`);
    loadBooks();
}


