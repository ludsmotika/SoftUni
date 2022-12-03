import { login } from "../api/api.js";
import { html } from "../library.js";


let template = (onLogin) => html`<section id="loginPage">
<form class="loginForm" @submit=${onLogin}>
    <img src="./images/logo.png" alt="logo" />
    <h2>Login</h2>

    <div>
        <label for="email">Email:</label>
        <input id="email" name="email" type="text" placeholder="steven@abv.bg" value="">
    </div>

    <div>
        <label for="password">Password:</label>
        <input id="password" name="password" type="password" placeholder="********" value="">
    </div>

    <button class="btn" type="submit">Login</button>

    <p class="field">
        <span>If you don't have profile click <a href="/register">here</a></span>
    </p>
</form>
</section>`;


export async function showLogin(ctx) {
    ctx.render(template(onLogin));

    async function onLogin(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let {email,password} = Object.fromEntries(form);
        if(email=='' || password==''){
            alert('Not all fields are filled');
            return;
        }
        await login(email, password);
        ctx.refreshNavBar();
        ctx.page.redirect('/');
    }
}

