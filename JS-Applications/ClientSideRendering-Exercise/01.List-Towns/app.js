import { html, render } from '../node_modules/lit-html/lit-html.js';

document.getElementById('btnLoadTowns').addEventListener('click', displayData);
let showData = (data) => html`<ul>${data.map(x => html`<li>${x}</li>`)}</ul>`;

function displayData(e) {
    e.preventDefault();
    let data = document.getElementById('towns').value.split(', ');
    render(showData(data), document.getElementById('root'));
}