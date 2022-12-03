import { getOfferById } from '../api/data.js';
import { getUserData } from '../api/util.js';
import { html, nothing } from '../library.js';

let template = (offer, isOwner) => html`<section id="details">
<div id="details-wrapper">
  <img id="details-img" src="${offer.imageUrl}" alt="example1" />
  <p id="details-title">${offer.title}</p>
  <p id="details-category">
    Category: <span id="categories">${offer.category}</span>
  </p>
  <p id="details-salary">
    Salary: <span id="salary-number">${offer.salary}</span>
  </p>
  <div id="info-wrapper">
    <div id="details-description">
      <h4>Description</h4>
      <span
        >${offer.description}</span
      >
    </div>
    <div id="details-requirements">
      <h4>Requirements</h4>
      <span
        >${offer.requirements}</span
      >
    </div>
  </div>
  <p>Applications: <strong id="applications">1</strong></p>

  ${isOwner ? html`<div id="action-buttons">
  <a href="/edit/${offer._id}" id="edit-btn">Edit</a>
  <a href="/delete/${offer._id}" id="delete-btn">Delete</a>
</div>`: nothing}
  
</div>
</section`;


export async function showDetails(ctx) {
    let id = ctx.params.id;
    let user = await getUserData();
    let isOwner = false;
    let offer = await getOfferById(id);
    if (user._id === offer._ownerId) {
        isOwner = true;
    }

    ctx.render(template(offer, isOwner));
}