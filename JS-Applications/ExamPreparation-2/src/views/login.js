import { login } from '../api/util.js';
import { html } from '../library.js';

let template = (onLogin) => html`  <section id="loginPage">
<form @submit=${onLogin}>
    <fieldset>
        <legend>Login</legend>

        <label for="email" class="vhide">Email</label>
        <input id="email" class="email" name="email" type="text" placeholder="Email">

        <label for="password" class="vhide">Password</label>
        <input id="password" class="password" name="password" type="password" placeholder="Password">

        <button type="submit" class="login">Login</button>

        <p class="field">
            <span>If you don't have profile click <a href="#">here</a></span>
        </p>
    </fieldset>
</form>
</section>`;

export async function showLogin(ctx) {
    ctx.render(template(onLogin));

    async function onLogin(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let data = Object.fromEntries(form);

        let email = data.email;
        let password = data.password;
        await login(email, password);
        ctx.refreshNavigationBar();
        ctx.page.redirect('/');
    }
}