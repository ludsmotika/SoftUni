import { get } from './api.js'
import { showView } from './navigator.js';

export async function logoutUser() {

    let responce = await fetch('http://localhost:3030/users/logout', {
        method: 'GET',
        headers: {
            'X-Authorization': localStorage.getItem('accessToken')
        }
    });
    localStorage.clear();
    showView('/home');
}