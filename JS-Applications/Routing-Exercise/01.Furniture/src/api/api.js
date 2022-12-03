let host = 'http://localhost:3030';


async function request(method, url, data) {
    let options = {
        method,
        headers: {}
    };

    if (data) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    let token = sessionStorage.getItem('userToken');
    if (token !== null) {
        options.headers['X-Authorization'] = token;
    }

    try {
        let responce = await fetch(host + url, options);
        if (responce.status == '204') {
            return responce;
        }

        if(responce.ok!=true){
            throw new Error(responce.statusText);
        }


        let answer = await responce.json();
        return answer;
    } catch (error) {
        alert(error.message)
        throw error;
    }
}

let get = request.bind(null, 'GET');
let post = request.bind(null, 'POST');
let put = request.bind(null, 'PUT');
let del = request.bind(null, 'DELETE');

export { get, post, put, del };

export async function register(email, password) {
    let result = await post('/users/register', { email, password });

    sessionStorage.setItem('userId', result._id);
    sessionStorage.setItem('userToken', result.accessToken);
    sessionStorage.setItem('userEmail', result.email);
    return await result;
}


export async function login(email, password) {
    let result = await post('/users/login', { email, password });

    sessionStorage.setItem('userId', result._id);
    sessionStorage.setItem('userToken', result.accessToken);
    sessionStorage.setItem('userEmail', result.email);
    return await result;
}


export async function logout() {
    let responce = await get('/users/logout');

    sessionStorage.clear();

    return await responce;
}
