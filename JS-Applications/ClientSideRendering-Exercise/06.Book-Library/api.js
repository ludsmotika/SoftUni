let host = 'http://localhost:3030';

async function requster(method, url, data) {

    let options = {
        method,
        headers: {}
    }

    if (data) {
        options.headers = { 'Content-Type': 'application/json' };
        options.body = JSON.stringify(data);
    }

    let responce = await fetch(host + url, options);
    let answer = await responce.json();
    return answer;

}

let get = requster.bind(null, 'GET');
let post = requster.bind(null, 'POST');
let put = requster.bind(null, 'PUT');
let del = requster.bind(null, 'DELETE');

export { get, post, put, del }