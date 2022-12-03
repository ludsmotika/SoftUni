import { getAlbumById } from '../api/data.js';
import { getUserData } from '../api/util.js';
import { html, nothing } from '../library.js';

let template = (album, isOwner) => html`<section id="details">
<div id="details-wrapper">
  <p id="details-title">Album Details</p>
  <div id="img-wrapper">
    <img src="${album.imageUrl}" alt="example1" />
  </div>
  <div id="info-wrapper">
    <p><strong>Band:</strong><span id="details-singer">${album.singer}</span></p>
    <p>
      <strong>Album name:</strong><span id="details-album">${album.album}</span>
    </p>
    <p><strong>Release date:</strong><span id="details-release">${album.release}</span></p>
    <p><strong>Label:</strong><span id="details-label">${album.label}</span></p>
    <p><strong>Sales:</strong><span id="details-sales">${album.sales}</span></p>
  </div>
  
  <!--Edit and Delete are only for creator-->
  
  <div id="action-buttons">
            <a href="/like" id="like-btn">Like</a>
            ${isOwner ? html`<a href="/edit/${album._id}" id="edit-btn">Edit</a>
            <a href="/delete/${album._id}" id="delete-btn">Delete</a>` : nothing}
            
          </div>

</div>
</section>`;


export async function showDetails(ctx) {
  let id = ctx.params.id;
  let album = await getAlbumById(id);
  let user = await getUserData();

  let isOwner = false;
  if (user != null) {

    if (user._id === album._ownerId) {
      isOwner = true;
    }
  }

  ctx.render(template(album, isOwner));
}