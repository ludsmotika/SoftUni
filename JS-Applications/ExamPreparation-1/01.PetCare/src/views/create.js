import { addPetToCatalog } from '../api/data.js';
import { html } from '../library.js';

let template = (onCreate) => html` <section id="createPage">
<form @submit=${onCreate} class="createForm">
    <img src="./images/cat-create.jpg">
    <div>
        <h2>Create PetPal</h2>
        <div class="name">
            <label for="name">Name:</label>
            <input name="name" id="name" type="text" placeholder="Max">
        </div>
        <div class="breed">
            <label for="breed">Breed:</label>
            <input name="breed" id="breed" type="text" placeholder="Shiba Inu">
        </div>
        <div class="Age">
            <label for="age">Age:</label>
            <input name="age" id="age" type="text" placeholder="2 years">
        </div>
        <div class="weight">
            <label for="weight">Weight:</label>
            <input name="weight" id="weight" type="text" placeholder="5kg">
        </div>
        <div class="image">
            <label for="image">Image:</label>
            <input name="image" id="image" type="text" placeholder="./image/dog.jpeg">
        </div>
        <button class="btn" type="submit">Create Pet</button>
    </div>
</form>
</section>`;

export async function showCreate(ctx) {
    ctx.render(template(onCreate));

    async function onCreate(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let data = Object.fromEntries(form);
        if (data.name == '' || data.breed == '' || data.age == '' || data.weight == '' || data.image == '') {
            alert('All fields must be filled');
            return;
        }

        await addPetToCatalog(data);
        ctx.page.redirect('/');
    }
}