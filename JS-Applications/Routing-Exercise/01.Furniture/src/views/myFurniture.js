import { getMyFurniture } from '../api/data.js';
import {html} from '../library.js'

let template = (content) => html`<div class="row space-top">
<div class="col-md-12">
    <h1>My Furniture</h1>
    <p>This is a list of your publications.</p>
</div>
</div>
<div class="row space-top">${content.map(item => currentItemTemplate(item))}</div>`;


let currentItemTemplate = (item) => html` <div class="col-md-4">
<div class="card text-white bg-primary">
    <div class="card-body">
            <img src="${item.img}" />
            <p>${item.description}</p>
            <footer>
                <p>Price: <span>${item.price} $</span></p>
            </footer>
            <div>
                <a href="/details/${item._id}" class="btn btn-info">Details</a>
            </div>
    </div>
</div>
</div>`;


export async function myFurnitureView(ctx){
let userId= sessionStorage.getItem('userId');

let furniture= await getMyFurniture(userId);

    ctx.render(template(furniture));
}