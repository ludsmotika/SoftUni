import { changeView, refreshNavBar } from './navigator.js'
import { post } from './api.js'

document.getElementById('registerButton').addEventListener('click', register);

async function register(e) {

    e.preventDefault();

    let form = new FormData(document.getElementById('register-form'));
    let { email, password, repeatPassword } = Object.fromEntries(form);

    if (password.length < 6 || repeatPassword != password || email == '') {
        return;
    }
    else {
        try {

            let user = await post('/users/register', { email, password });

            if (user) {
                localStorage.setItem('accessToken', user.accessToken);
                localStorage.setItem('_id', user._id);
                localStorage.setItem('email', user.email);
                localStorage.setItem('username', user.username);
            }

        } catch (error) {
            alert(error.message);
            return;
        }


    }

    changeView('/home');
    refreshNavBar();

}