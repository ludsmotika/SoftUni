import { getAlbumById } from '../api/data.js';
import { getUserData } from '../api/util.js';
import { html, nothing } from '../library.js';

let template = (album, isOwner) => html`<section id="detailsPage">
<div class="wrapper">
    <div class="albumCover">
        <img src="${album.imgUrl} ">
    </div>
    <div class="albumInfo">
        <div class="albumText">

            <h1>Name: ${album.name}</h1>
            <h3>Artist: ${album.artist}</h3>
            <h4>Genre: ${album.genre}</h4>
            <h4>Price: $${album.price}</h4>
            <h4>Date: ${album.releaseDate}</h4>
            <p>Description: ${album.description}</p>
        </div>

        ${isOwner ? html`<div class="actionBtn">
        <a href="/edit/${album._id}" class="edit">Edit</a>
        <a href="/delete/${album._id}" class="remove">Delete</a>
    </div>`: nothing}

    </div>
</div>
</section>`;

export async function showDetails(ctx) {
    let id = ctx.params.id;
    let album = await getAlbumById(id);

    let user = await getUserData();

    let isOwner = (user._id == album._ownerId ? true : false);

    ctx.render(template(album, isOwner));
}