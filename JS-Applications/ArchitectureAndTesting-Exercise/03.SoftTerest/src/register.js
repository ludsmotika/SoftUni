import { post } from './api.js'
import { showView } from './navigator.js';

export async function registerUser(e) {
    e.preventDefault();
    let form = new FormData(document.getElementById('registerForm'));
    let data = Object.fromEntries(form);

    try {
        if (data.email.length < 3 || data.password < 3 || data.password != data.repeatPassword) {
            throw new Error('invalid input!');
        }
        let requestBody = { email: data.email, password: data.password };

        let responceBody = await post('/users/register', requestBody);

        localStorage.setItem('email', responceBody.email);
        localStorage.setItem('password', responceBody.password);
        localStorage.setItem('accessToken', responceBody.accessToken);

        showView('/home');
    }
    catch (error) {
        console.log(error.message)
    }

}