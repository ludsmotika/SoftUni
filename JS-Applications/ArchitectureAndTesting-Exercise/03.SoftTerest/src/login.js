import { post } from './api.js'
import { showView } from './navigator.js';

export async function loginUser(e) {
    e.preventDefault();
    let form = new FormData(document.getElementById('loginForm'));
    let data = Object.fromEntries(form);

    let dataObj = {
        email: data.email,
        password: data.password
    }

    let responceBody = await post('/users/login', dataObj);

    if (responceBody) {
        localStorage.setItem('email', responceBody.email);
        localStorage.setItem('password', responceBody.password);
        localStorage.setItem('accessToken', responceBody.accessToken);
        showView('/home');
    }
    else {
        //clearInputFields
    }
}