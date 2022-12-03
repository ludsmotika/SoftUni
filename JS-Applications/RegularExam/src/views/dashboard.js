import { getAllAlbums } from '../api/data.js';
import { html } from '../library.js';

let template = (albums) => html`<section id="dashboard">
<h2>Albums</h2>
<ul class="card-wrapper">
  ${albums.length != 0 ? albums.map(album => currentAlbumTemplate(album)) : html`
  <h2>There are no albums added yet.</h2>` }
</ul>


</section>`;


let currentAlbumTemplate = (album) => html`<li class="card">
<img src="${album.imageUrl}" alt="travis" />
<p>
  <strong>Singer/Band: </strong><span class="singer">${album.singer}</span>
</p>
<p>
  <strong>Album name: </strong><span class="album">${album.album}</span>
</p>
<p><strong>Sales:</strong><span class="sales">${album.sales}</span></p>
<a class="details-btn" href="/details/${album._id}">Details</a>
</li>`;


export async function showDashboard(ctx) {
    let albums = await getAllAlbums();
    ctx.render(template(albums));
}