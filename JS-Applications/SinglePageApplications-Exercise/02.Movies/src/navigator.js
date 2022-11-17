import { loadMovies } from './movies.js'


let views = {
    '/home': showHomeView,
    '/register': showRegisterView,
    '/login': showLoginView,
    '/logout': logoutView
}

export function changeView(url) {

    document.querySelectorAll('section').forEach(x => x.style.display = 'none');
    let view = views[url];
    view();

}

export function refreshNavBar() {
    let email = localStorage.getItem('email');
    if (email) {
        document.getElementById('welcome-msg').textContent = `Welcome, ${email}`;
        document.querySelectorAll('.user').forEach(x => x.style.display = 'block');
        document.querySelectorAll('.guest').forEach(x => x.style.display = 'none');
    }
    else {
        document.querySelectorAll('.user').forEach(x => x.style.display = 'none');
        document.querySelectorAll('.guest').forEach(x => x.style.display = 'block');
    }
}


function showHomeView() {
    document.getElementById('home-page').style.display = 'block';
    loadMovies();
    refreshNavBar();
}

function showLoginView() {
    document.getElementById('form-login').style.display = 'block';
}

function showRegisterView() {
    document.getElementById('form-sign-up').style.display = 'block';
}

function logoutView() {
    localStorage.clear();
    refreshNavBar();
    changeView('/login');
}