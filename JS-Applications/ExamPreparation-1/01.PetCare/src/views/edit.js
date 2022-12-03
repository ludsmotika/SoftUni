import { getPetById, updateCat } from '../api/data.js';
import { html } from '../library.js'


let template = (pet, onSubmit) => html`    <!--Edit Page-->
<section id="editPage">
    <form @submit=${onSubmit} class="editForm">
        <img src="${pet.image}">
        <div>
            <h2>Edit PetPal</h2>
            <div class="name">
                <label for="name">Name:</label>
                <input name="name" id="name" type="text" value="${pet.name}">
            </div>
            <div class="breed">
                <label for="breed">Breed:</label>
                <input name="breed" id="breed" type="text" value="${pet.breed}">
            </div>
            <div class="Age">
                <label for="age">Age:</label>
                <input name="age" id="age" type="text" value="${pet.age}">
            </div>
            <div class="weight">
                <label for="weight">Weight:</label>
                <input name="weight" id="weight" type="text" value="${pet.weight}">
            </div>
            <div class="image">
                <label for="image">Image:</label>
                <input name="image" id="image" type="text" value="${pet.image}">
            </div>
            <button class="btn" type="submit">Edit Pet</button>
        </div>
    </form>
</section>`;

export async function showEdit(ctx) {
    let pet = await getPetById(ctx.params.id);
    ctx.render(template(pet, onSubmit));

    async function onSubmit(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let data = Object.fromEntries(form);

        if (data.name == '' || data.breed == '' || data.age == '' || data.weight == '' || data.image == '') {
            alert('All fields must be filled');
            return;
        }

        await updateCat(ctx.params.id, data);
        ctx.page.redirect(`/details/${pet._id}`);
    }
} 