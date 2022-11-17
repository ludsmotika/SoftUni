import { showView } from './navigator.js';
import { registerUser } from './register.js';
import { loginUser } from './login.js';
import { logoutUser } from './logout.js';

document.getElementById('registerButton').addEventListener('click', registerUser);
document.getElementById('loginButton').addEventListener('click', loginUser);

showView('/home');

let anchors = document.getElementsByTagName('A');

for (let current of anchors) {
    current.addEventListener('click', routeToView);
}

function routeToView(e) {
    e.preventDefault();
    let url = e.target.getAttribute('href');
    showView(url);
}
