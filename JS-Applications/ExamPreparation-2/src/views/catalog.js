import { getAllAlbums } from '../api/data.js';
import { getUserData } from '../api/util.js';
import { html, nothing } from '../library.js'

let catalogTemplate = (albums, user) => html`  <section id="catalogPage">
<h1>All Albums</h1>

${albums.length == 0 ? html`<p>No Albums in Catalog!</p>` : albums.map(album => currentAlbumTemplate(album, user))}

</section>`;

let currentAlbumTemplate = (album, user) => html`<div class="card-box">
<img src="${album.imgUrl}">
<div>
    <div class="text-center">
        <p class="name">Name: ${album.name}</p>
        <p class="artist">Artist: ${album.artist}</p>
        <p class="genre">Genre: ${album.genre}</p>
        <p class="price">Price: $${album.price}</p>
        <p class="date">Release Date: ${album.releaseDate}</p>
    </div>
    <div class="btn-group">
    ${user ? html` <a href="/details/${album._id}" id="details">Details</a>` : nothing}
    </div>
</div>
</div>`;


export async function showCatalog(ctx) {
    let albums = await getAllAlbums();
    let user = await getUserData() ? true : false;
    ctx.render(catalogTemplate(albums, user));
}