import { deleteFurniture, furnitureDetails } from '../api/data.js';
import { html } from '../library.js';

let template = (item, ownerId) => html`<div class="row space-top">
<div class="col-md-12">
    <h1>Furniture Details</h1>
</div>
</div>
<div class="row space-top">
<div class="col-md-4">
    <div class="card text-white bg-primary">
        <div class="card-body">
            <img src="/images/chair.jpg" />
        </div>
    </div>
</div>
<div class="col-md-4">
    <p>Make: <span>${item.make}</span></p>
    <p>Model: <span>${item.model}</span></p>
    <p>Year: <span>${item.year}</span></p>
    <p>Description: <span>${item.description}</span></p>
    <p>Price: <span>${item.price}</span></p>
    <p>Material: <span>${item.material}</span></p>
    <div>
        <a href="/edit/${item._id}" style=${item._ownerId == ownerId ? "display: inline" : "display: none"} class="btn btn-info">Edit</a>
        <a id='deleteBtn'  style=${item._ownerId == ownerId ? "display: inline" : "display: none"} class="btn btn-red">Delete</a>
    </div>
</div>
</div>`;


export async function detailsView(ctx) {

    let id = ctx.params.id;
    let currentElement = await furnitureDetails(id);
    let ownerId = sessionStorage.getItem('userId');

    ctx.render(template(currentElement, ownerId));

    await onDelete(ctx, id);
}

async function onDelete(ctx, id) {
    const deleteBtn = document.getElementById('deleteBtn');
    deleteBtn.addEventListener('click', deleteBtnClick);

    async function deleteBtnClick(e) {
        confirm("Do you want to delete the item?");
        await deleteFurniture(id);
        ctx.refreshNavBar();
        ctx.page.redirect('/');
    }
}