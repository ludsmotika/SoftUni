import { register } from '../api/util.js';
import { html } from '../library.js'

let template = (onRegister) => html` <section id="registerPage">
<form @submit=${onRegister}>
    <fieldset>
        <legend>Register</legend>

        <label for="email" class="vhide">Email</label>
        <input id="email" class="email" name="email" type="text" placeholder="Email">

        <label for="password" class="vhide">Password</label>
        <input id="password" class="password" name="password" type="password" placeholder="Password">

        <label for="conf-pass" class="vhide">Confirm Password:</label>
        <input id="conf-pass" class="conf-pass" name="conf-pass" type="password" placeholder="Confirm Password">

        <button type="submit" class="register">Register</button>

        <p class="field">
            <span>If you already have profile click <a href="#">here</a></span>
        </p>
    </fieldset>
</form>
</section>`;


export async function showRegister(ctx) {
    ctx.render(template(onRegister));

    async function onRegister(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let data = Object.fromEntries(form);

        let email = data.email;
        let password = data.password;
        let repeatPassoword = data['conf-pass'];


        //check on exam if there is a problem with register with empty fields because it has strange behavior
        if (password != repeatPassoword || email === '' || password === '' || repeatPassoword === '') {
            alert('invalid input');
            return;
        }
        else {
            await register(email, password);
            ctx.refreshNavigationBar();
            ctx.page.redirect('/');
        }

    }


}