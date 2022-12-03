import { get, post } from './api.js';

//register

export async function register(email, password) {
    let answer = await post('/users/register', { email, password });
    setUserData(answer);
    return answer;
}
//login

export async function login(email, password) {
    let answer = await post('/users/login', { email, password });
    setUserData(answer);
    return answer;
}
//logout

export async function logout() {
    await get('/users/logout');
    clearUserData();
}

//get set del userData

export async function getUserData() {
    let userData = JSON.parse(sessionStorage.getItem('userData'));
    return userData;
}

export async function setUserData(data) {
    sessionStorage.setItem('userData', JSON.stringify(data));
}

async function clearUserData() {
    sessionStorage.removeItem('userData');
}
