import { register } from '../api/api.js';
import { html } from '../library.js'

let template = (onRegister) => html`<div class="row space-top">
<div class="col-md-12">
    <h1>Register New User</h1>
    <p>Please fill all fields.</p>
</div>
</div>
<form @submit= ${onRegister}>
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
        <div class="form-group">
            <label class="form-control-label" for="rePass">Repeat</label>
            <input class="form-control" id="rePass" type="password" name="rePass">
        </div>
        <input type="submit" class="btn btn-primary" value="Register" />
    </div>
</div>
</form>`;

export async function registerView(ctx) {

    ctx.render(template(onRegister));

    async function onRegister(e) {
        e.preventDefault();

        let form = new FormData(document.querySelector('form'));
        let { email, password, rePass } = Object.fromEntries(form);


        if (email !== '' && password !== '' && rePass !== '') {

            if (password === rePass) {

                await register(email, password);
                ctx.page.redirect('/');
            }
        }
        
        ctx.refreshNavBar();
    }
}

