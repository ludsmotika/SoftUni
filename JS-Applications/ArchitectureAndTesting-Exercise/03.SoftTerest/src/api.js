const hostURL = 'http://localhost:3030'

async function requester(method, url, data) {
    let options = {
        method,
        headers:{}
    };

    if (data) {
        options.headers = { 'Content-Type': 'application/json' };
        options.body = JSON.stringify(data);
    }

    try {
        let responce = await fetch(hostURL + url, options);
        if (!responce.ok) {
            throw new Error('invalid input!!!');
        }
        let obj = await responce.json();
        return obj;
    }
    catch (error) {
        alert(error.message);
        throw error;
    }
}


let get = requester.bind(null, 'GET');
let post = requester.bind(null, 'POST');
let put = requester.bind(null, 'PUT');
let del = requester.bind(null, 'DELETE');

export { get, post, put, del }


