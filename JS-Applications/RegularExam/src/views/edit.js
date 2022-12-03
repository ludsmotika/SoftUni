import { getAlbumById, updateAlbum } from '../api/data.js';
import { html } from '../library.js';

let template = (album, onEdit) => html`<section id="edit">
<div class="form">
  <h2>Edit Album</h2>
  <form class="edit-form" @submit= ${onEdit}>
    <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" value= '${album.singer}' />
    <input type="text" name="album" id="album-album" placeholder="Album" value= '${album.album}' />
    <input type="text" name="imageUrl" id="album-img" placeholder="Image url" value= '${album.imageUrl}'/>
    <input type="text" name="release" id="album-release" placeholder="Release date" value= '${album.release}'/>
    <input type="text" name="label" id="album-label" placeholder="Label" value= '${album.label}'/>
    <input type="text" name="sales" id="album-sales" placeholder="Sales" value= '${album.sales}'/>

    <button type="submit">post</button>
  </form>
</div>
</section>`;


export async function showEdit(ctx) {

    let id = ctx.params.id;
    let album = await getAlbumById(id);
    ctx.render(template(album, onEdit));

    async function onEdit(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let data = Object.fromEntries(form);

        if (data.singer === '' || data.album === '' || data.imageUrl === '' || data.release === '' || data.label === '' || data.sales === '') {
            alert('all input fields must be filled');
            return;
        }
        else {
            await updateAlbum(id, data);
            ctx.page.redirect(`/details/${id}`);
        }
    }
}