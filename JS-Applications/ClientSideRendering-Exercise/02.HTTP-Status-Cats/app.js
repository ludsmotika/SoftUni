import { cats } from './catSeeder.js';
import { html, render } from '../node_modules/lit-html/lit-html.js'

let showCats = (cats) => html`<ul>
${cats.map(cat => html`<li>
<img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
<div class="info">
    <button class="showBtn">Show status code</button>
    <div class="status" style="display: none" id="${cat.id}">
        <h4>Status Code: ${cat.statusCode}</h4>
        <p>${cat.statusMessage}</p>
    </div>
</div>
</li>`)}
</ul>`;

renderAllCats(cats);

function renderAllCats(data) {
    render(showCats(data), document.getElementById('allCats'));
}

document.getElementById('allCats').addEventListener('click', toogleButton);

function toogleButton(e) {
    e.preventDefault();
    if (e.target.tagName == 'BUTTON') {
        if (e.target.textContent == 'Show status code') {
            e.target.parentElement.children[1].style.display = 'block';
            e.target.textContent = 'Hide status code'
        }
        else {
            e.target.parentElement.children[1].style.display = 'none';
            e.target.textContent = 'Show status code'
        }
        renderAllCats(cats);
    }
}