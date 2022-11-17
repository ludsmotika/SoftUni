import { get } from "./api.js";
import { logoutUser } from "./logout.js";

const views = {
    '/home': showHome,
    '/register': showRegister,
    '/login': showLogin,
    '/logout': showLogout,
    '/delete': deleteElement,
    '/ideas': showIdeas
}

//TODO delete and other views

export async function showView(viewURL) {
    let elements = document.querySelector('body').children;

    for (let current of elements) {
        current.style.display = 'none';
    }

    showNavigationBar();
    let view = views[viewURL];
    await view();
}

function showHome() {
    document.getElementById('home-div').style.display = 'block';
    document.getElementById('footer').style.display = 'block';
}

async function showIdeas() {
    let dashboard = document.getElementById('dashboard-holder');
   // dashboard.childNodes.forEach(x => x.style.display = 'none');
    dashboard.style.display = 'block';

    let ideas = await get('http://localhost:3030/data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc');
    //renderIdeas()
}

function showRegister() {
    document.getElementById('register-div').style.display = 'block';
}

function showLogin() {
    document.getElementById('login-div').style.display = 'block';
}

async function showLogout() {
    await logoutUser();
}

function deleteElement() { }

function showNavigationBar() {
    let email = localStorage.getItem('email');
    document.getElementById('navBarElement').style.display = 'block';
    document.getElementById('dashboardAnchor').style.display = 'block';

    if (email) {
        document.getElementById('createAnchor').style.display = 'block';
        document.getElementById('logoutAnchor').style.display = 'block';
        document.getElementById('registerAnchor').style.display = 'none';
        document.getElementById('loginAnchor').style.display = 'none';
    }
    else {
        document.getElementById('registerAnchor').style.display = 'block';
        document.getElementById('loginAnchor').style.display = 'block';
        document.getElementById('createAnchor').style.display = 'none';
        document.getElementById('logoutAnchor').style.display = 'none';
    }
}