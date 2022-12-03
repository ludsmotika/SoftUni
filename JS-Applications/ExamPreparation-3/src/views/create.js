import { postOffer } from '../api/data.js';
import { html } from '../library.js';

let template = (onCreate) => html` <section id="create">
<div class="form">
  <h2>Create Offer</h2>
  <form class="create-form" @submit=${onCreate}>
    <input
      type="text"
      name="title"
      id="job-title"
      placeholder="Title"
    />
    <input
      type="text"
      name="imageUrl"
      id="job-logo"
      placeholder="Company logo url"
    />
    <input
      type="text"
      name="category"
      id="job-category"
      placeholder="Category"
    />
    <textarea
      id="job-description"
      name="description"
      placeholder="Description"
      rows="4"
      cols="50"
    ></textarea>
    <textarea
      id="job-requirements"
      name="requirements"
      placeholder="Requirements"
      rows="4"
      cols="50"
    ></textarea>
    <input
      type="text"
      name="salary"
      id="job-salary"
      placeholder="Salary"
    />

    <button type="submit">post</button>
  </form>
</div>
</section>`;

export async function showCreate(ctx) {
    ctx.render(template(onCreate));

    async function onCreate(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let data = Object.fromEntries(form);

        if (data.title === '' || data.imageUrl === '' || data.category === '' || data.description === '' || data.requirements === '' || data.salary === '') {
            alert('all input fields must be filled');
            return;
        }
        else {
            await postOffer(data);
            ctx.page.redirect('/dashboard');
        }
    }
}