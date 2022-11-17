import { changeView, refreshNavBar } from './navigator.js'
import { post } from './api.js'

document.getElementById('loginButton').addEventListener('click', login);

async function login(e) {

    e.preventDefault();
    let form = new FormData(document.getElementById('login-form'));
    let { email, password } = Object.fromEntries(form);

    try {
        let user = await post('/users/login', { email, password });
        if (user) {
            localStorage.setItem('accessToken', user.accessToken);
            localStorage.setItem('_id', user._id);
            localStorage.setItem('email', user.email);
            localStorage.setItem('username', user.username);
            changeView('/home');
            refreshNavBar();
        }
    } catch (error) {
        alert(error.message);
        return;
    }

}
