import { changeView, refreshNavBar } from './navigator.js';


document.getElementById('container').addEventListener('click', routeToView);

refreshNavBar();
changeView('/home');


function routeToView(e) {
    e.preventDefault();

    if (e.target.tagName == 'A') {
        let url = e.target.getAttribute('href');
        changeView(url);
    }
}
