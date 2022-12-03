import { login } from '../api/util.js';
import { html } from '../library.js'

let template = (onLogin) => html`<section id="login">
<div class="form">
  <h2>Login</h2>
  <form class="login-form" @submit=${onLogin}>
    <input type="text" name="email" id="email" placeholder="email" />
    <input
      type="password"
      name="password"
      id="password"
      placeholder="password"
    />
    <button type="submit">login</button>
    <p class="message">
      Not registered? <a href="/register">Create an account</a>
    </p>
  </form>
</div>
</section>`;


export async function showLogin(ctx) {

  ctx.render(template(onLogin));

  async function onLogin(e) {
    e.preventDefault();
    let form = new FormData(e.target);
    let data = Object.fromEntries(form);

    if (data.email === '' || data.password === '') {
      alert('empty fields!');
      return;
    }
    else {
      await login(data.email, data.password);
      ctx.page.redirect('/');
      ctx.refreshNavBar();
    }
  }
}