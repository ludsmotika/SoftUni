import { html, render } from '../node_modules/lit-html/lit-html.js'

document.querySelector('input[type="submit"]').addEventListener('click', addItem);

let itemsHtml = (item) => html`<option value=${item.id}> ${item.text} </option>`;

await showItems();

async function addItem(e) {

    e.preventDefault();
    let toAdd = document.getElementById('itemText').value;

    let responce = await fetch('http://localhost:3030/jsonstore/advanced/dropdown', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ text: toAdd })
    });

    console.log(await responce.json());

    await showItems()

    document.getElementById('itemText').value = '';
}

async function showItems() {
    let responce = await fetch('http://localhost:3030/jsonstore/advanced/dropdown');
    let data = await responce.json();
    let list = [];

    for (let key in data) {
        list.push({
            id: data[key]._id,
            text: data[key].text
        });
    }

    console.log(list)

    render(list.map(itemsHtml), document.getElementById('menu'));
} 