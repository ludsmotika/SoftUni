import { register } from '../api/util.js';
import { html } from '../library.js';

let template = (onRegister) => html`<section id="register">
<div class="form">
  <h2>Register</h2>
  <form class="login-form" @submit=${onRegister}>
    <input type="text" name="email" id="register-email" placeholder="email" />
    <input type="password" name="password" id="register-password" placeholder="password" />
    <input type="password" name="re-password" id="repeat-password" placeholder="repeat password" />
    <button type="submit">register</button>
    <p class="message">Already registered? <a href="/login">Login</a></p>
  </form>
</div>
</section>`;

export async function showRegister(ctx) {
    ctx.render(template(onRegister));

    async function onRegister(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let data = Object.fromEntries(form);

        if (data.email === '' || data.password === '' || data['re-password'] === '' || data.password !== data['re-password']) {
            alert('all input fields must be filled');
            return;
        }
        else {
            await register(data.email, data.password);
            ctx.page.redirect('/dashboard');
            ctx.refreshNavBar();
        }

    }
}