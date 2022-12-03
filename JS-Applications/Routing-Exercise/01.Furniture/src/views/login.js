import { html } from '../library.js';
import { login } from "../api/api.js";

let template = (onLogin) => html` <div class="row space-top">
<div class="col-md-12">
    <h1>Login User</h1>
    <p>Please fill all fields.</p>
</div>
</div>
<form @submit= ${onLogin}>
<div class="row space-top">
    <div class="col-md-4">
        <div class="form-group">
            <label class="form-control-label" for="email">Email</label>
            <input class="form-control" id="email" type="text" name="email">
        </div>
        <div class="form-group">
            <label class="form-control-label" for="password">Password</label>
            <input class="form-control" id="password" type="password" name="password">
        </div>
        <input type="submit" class="btn btn-primary" value="Login" />
    </div>
</div>
</form>`;

export async function loginView(ctx) {
    ctx.render(template(onLogin));
    async function onLogin(e) {
        e.preventDefault();

        let form = new FormData(document.querySelector('form'));
        let { email, password } = Object.fromEntries(form);

        let responce = await login(email, password);

        ctx.page.redirect('/');
        ctx.refreshNavBar();
    }
}


