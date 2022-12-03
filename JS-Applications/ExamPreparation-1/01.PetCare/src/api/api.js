import { getUserData, setUserData, clearUserData } from "./util.js";

let host = 'http://localhost:3030';

async function request(method, url, data) {
    let options = {
        method,
        headers: {

        }
    }

    if (data) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    let user = await getUserData();

    if (user) {
        options.headers['X-Authorization'] = user.accessToken;
    }

    try {
        let responce = await fetch(host + url, options);

        if (responce.status == '204') {
            return responce;
        }

        let answer = await responce.json();

        if (!responce.ok) {
            throw new Error(answer.message);
        }

        return answer;

    } catch (error) {
        alert(error.message);
        throw error;
    }
}


let get = request.bind(null, 'GET');
let post = request.bind(null, 'POST');
let put = request.bind(null, 'PUT');
let del = request.bind(null, 'DELETE');

export { get, post, put, del };

export async function register(email, password) {
    let answer = await post('/users/register', { email, password });
    setUserData(answer);
}

export async function login(email, password) {
    let answer = await post('/users/login', { email, password });
    setUserData(answer);
}

export async function logout() {
    await get('/users/logout');
    clearUserData();
}