import { logout } from './api/api.js';
import { page, render } from './library.js';
import { catalogView } from './views/catalog.js';
import { createView } from './views/create.js';
import { detailsView } from './views/details.js';
import { showEditPage } from './views/edit.js';
import { loginView } from './views/login.js';
import { myFurnitureView } from './views/myFurniture.js';
import { registerView } from './views/register.js';

let root = document.querySelector('div.container');
refreshNavBar();

page(decorator);
page('/', catalogView);
page('/register', registerView);
page('/login', loginView);
page('/details/:id', detailsView);
page('/edit/:id', showEditPage);
page('/create', createView);
page('/my-furniture', myFurnitureView);

page.start()


page.redirect('/');

function decorator(ctx, next) {
    ctx.render = (content) => render(content, root);
    ctx.refreshNavBar = () => refreshNavBar();
    next();
}


function refreshNavBar() {
    if (sessionStorage.getItem('userEmail') === null) {
        document.getElementById('user').style.display = 'none';
        document.getElementById('guest').style.display = 'inline-block';
    }
    else {
        document.getElementById('user').style.display = 'inline-block';
        document.getElementById('guest').style.display = 'none';
    }
}

document.getElementById('logoutBtn').addEventListener('click',onLogout);

async function onLogout(e){
    e.preventDefault();
    await logout();
    refreshNavBar();
    page.redirect('/');
} 