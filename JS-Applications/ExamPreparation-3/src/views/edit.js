import { editOffer, getOfferById } from '../api/data.js';
import { html } from '../library.js';

let template = (offer, onEdit) => html`<section id="edit">
<div class="form">
  <h2>Edit Offer</h2>
  <form class="edit-form" @submit = ${onEdit}>
    <input
      type="text"
      name="title"
      id="job-title"
      value="${offer.title}"
    />
    <input
      type="text"
      name="imageUrl"
      id="job-logo"
      value="${offer.imageUrl}"
    />
    <input
      type="text"
      name="category"
      id="job-category"
      value="${offer.category}"
    />
    <textarea
      id="job-description"
      name="description"
      placeholder="Description"
      rows="4"
      cols="50"
    >${offer.description}</textarea>
      
    <textarea
      id="job-requirements"
      name="requirements"
      placeholder="Requirements"
      rows="4"
      cols="50"
    >${offer.requirements}</textarea>
    <input
      type="text"
      name="salary"
      id="job-salary"
      value="${offer.salary}"
    />

    <button type="submit">post</button>
  </form>
</div>
</section>`;

export async function showEdit(ctx) {
    let id = ctx.params.id;
    let offer = await getOfferById(id);

    ctx.render(template(offer, onEdit));

    async function onEdit(e) {
        e.preventDefault();

        let form = new FormData(e.target);
        let data = Object.fromEntries(form);

        if (data.title === '' || data.imageUrl === '' || data.category === '' || data.description === '' || data.requirements === '' || data.salary === '') {
            alert('all input fields must be filled');
            return;
        }
        else {
            await editOffer(id, data);
            ctx.page.redirect(`/details/${id}`);
        }
    }
}