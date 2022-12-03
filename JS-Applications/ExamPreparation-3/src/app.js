import { deleteOffer } from './api/data.js';
import { getUserData, logout } from './api/util.js';
import { page, render } from './library.js';
import { showCreate } from './views/create.js';
import { showDashboard } from './views/dashboard.js';
import { showDetails } from './views/details.js';
import { showEdit } from './views/edit.js';
import { showHome } from './views/home.js';
import { showLogin } from './views/login.js';
import { showRegister } from './views/register.js';

let mainElement = document.getElementById('mainElement');

page(contextDecorator);
page('/', showHome);
page('/login', showLogin);
page('/register', showRegister);
page('/dashboard', showDashboard);
page('/create', showCreate);
page('/details/:id', showDetails);
page('/edit/:id', showEdit);
page('/delete/:id', onDelete);
page('/logout', onLogout);


page.start();

refreshNavBar();
page.redirect('/');


async function contextDecorator(ctx, next) {
    ctx.render = (content) => render(content, mainElement);
    ctx.refreshNavBar = refreshNavBar;

    next();
}

async function refreshNavBar() {
    let user = await getUserData();
    if (user) {
        document.querySelector('div .user').style.display = 'block';
        document.querySelector('div .guest').style.display = 'none';
    }
    else {
        document.querySelector('div .user').style.display = 'none';
        document.querySelector('div .guest').style.display = 'block';
    }

}

async function onLogout(ctx) {
    await logout();
    ctx.page.redirect('/dashboard');
    ctx.refreshNavBar();
}

async function onDelete(ctx) {
    let id = ctx.params.id;
    await deleteOffer(id);
    page.redirect('/dashboard');
}