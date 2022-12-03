import { getPetById } from '../api/data.js';
import { getUserData } from '../api/util.js';
import { html, nothing } from '../library.js';

let template = (pet, userId) => html`<section id="detailsPage">
            <div class="details">
                <div class="animalPic">
                    <img src="${pet.image}">
                </div>
                <div>
                    <div class="animalInfo">
                        <h1>Name: ${pet.name}</h1>
                        <h3>Breed: ${pet.breed}</h3>
                        <h4>Age: ${pet.age}</h4>
                        <h4>Weight: ${pet.weight}</h4>
                        <h4 class="donation">Donation: 0$</h4>
                    </div>
                    <!-- if there is no registered user, do not display div-->

                    ${userId == '' ? nothing : userId == pet._ownerId ? html`<div class="actionBtn">
                    <!-- Only for registered user and creator of the pets-->
                    <a href="/edit/${pet._id}" class="edit">Edit</a>
                    <a href="/delete/${pet._id}" class="remove">Delete</a>
                </div>`: nothing}
                    
                </div>
            </div>
        </section>`;


export async function showDetails(ctx) {

    let id = ctx.params.id;
    let userData = await getUserData();
    let userId = '';
    if (userData != null) {
        userId = userData._id;
    }

    let pet = await getPetById(id);
    ctx.render(template(pet, userId));
}