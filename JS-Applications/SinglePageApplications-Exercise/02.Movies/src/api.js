let host = 'http://localhost:3030';

async function sendRequest(method, url, data) {

    let options = {
        method,
        headers: {}
    }

    if (data) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    // TODO: error handling

    try {
        let responce = await fetch(host + url, options);

        if (!responce.ok) {
            throw new Error('invalid input!');
        }

        let asnwer = await responce.json();

        return asnwer;
    } catch (error) {
        alert(error.message);
        throw error;
    }



}

let get = sendRequest.bind(null, 'GET');
let post = sendRequest.bind(null, 'POST');
let put = sendRequest.bind(null, 'PUT');
let del = sendRequest.bind(null, 'DELETE');


export { get, post, put, del };