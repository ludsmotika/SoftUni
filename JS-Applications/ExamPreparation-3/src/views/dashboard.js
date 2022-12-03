import { getAllOffers } from '../api/data.js';
import { html } from '../library.js';

let template = (offers) => html`<section id="dashboard">
<h2>Job Offers</h2>

${offers.length != 0 ? offers.map(x => offerTemplate(x)) : html`<h2>No offers yet.</h2>`}

</section>`;


let offerTemplate = (offer) => html`<div class="offer">
<img src="${offer.imageUrl}" alt="./images/example3.png" />
<p>
  <strong>Title: </strong
  ><span class="title">${offer.title}</span>
</p>
<p><strong>Salary:</strong><span class="salary">${offer.salary}</span></p>
<a class="details-btn" href="/details/${offer._id}">Details</a>
</div>`;


export async function showDashboard(ctx) {
  let offers = await getAllOffers();
  ctx.render(template(offers));
}