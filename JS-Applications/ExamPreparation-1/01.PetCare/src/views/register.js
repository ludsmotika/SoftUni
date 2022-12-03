import { register } from "../api/api.js";
import { html } from "../library.js";


let template = (onRegister) => html`<section id="registerPage">
<form  @submit= ${onRegister} class="registerForm">
    <img src="./images/logo.png" alt="logo" />
    <h2>Register</h2>
    <div class="on-dark">
        <label for="email">Email:</label>
        <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
    </div>

    <div class="on-dark">
        <label for="password">Password:</label>
        <input id="password" name="password" type="password" placeholder="********" value="">
    </div>

    <div class="on-dark">
        <label for="repeatPassword">Repeat Password:</label>
        <input id="repeatPassword" name="repeatPassword" type="password" placeholder="********" value="">
    </div>

    <button class="btn" type="submit">Register</button>

    <p class="field">
        <span>If you have profile click <a href="/login">here</a></span>
    </p>
</form>
</section>`;


export async function showRegister(ctx) {
    ctx.render(template(onRegister));

    async function onRegister(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let { email, password, repeatPassword } = Object.fromEntries(form);

        if (email == '' || password == '' || repeatPassword=='' || repeatPassword!=password) {
            alert('Not all fields are filled');
            return;
        }

        await register(email, password);
        ctx.refreshNavBar();
        ctx.page.redirect('/');
    }
}

