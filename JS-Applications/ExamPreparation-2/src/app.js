import { removeAlbumFromServer } from './api/data.js';
import { getUserData, logout } from './api/util.js';
import { page, render } from './library.js';
import { showCatalog } from './views/catalog.js';
import { showCreate } from './views/create.js';
import { showDetails } from './views/details.js';
import { showEdit } from './views/edit.js';
import { showHome } from './views/home.js';
import { showLogin } from './views/login.js';
import { showRegister } from './views/register.js'

let mainElement = document.getElementById("main-content");

page(contextDecorator);
page('/', showHome);
page('/register', showRegister);
page('/login', showLogin);
page('/logout', onLogout);
page('/catalog', showCatalog);
page('/create', showCreate);
page('/details/:id', showDetails);
page('/edit/:id', showEdit);
page('/delete/:id', deleteAlbum)

page.start();


page.redirect('/');
refreshNavigationBar();

async function deleteAlbum(ctx) {
    let id = ctx.params.id;
    let answer = await removeAlbumFromServer(id);
    ctx.page.redirect('/catalog');
}

async function contextDecorator(ctx, next) {
    ctx.render = (content) => render(content, mainElement);
    ctx.refreshNavigationBar = refreshNavigationBar;

    next();
}

async function refreshNavigationBar() {
    let userData = await getUserData();
    if (userData) {
        document.getElementById('loginAnchor').style.display = 'none';
        document.getElementById('registerAnchor').style.display = 'none';
        document.getElementById('createAnchor').style.display = 'block';
        document.getElementById('logoutAnchor').style.display = 'block';
    }
    else {
        document.getElementById('loginAnchor').style.display = 'block';
        document.getElementById('registerAnchor').style.display = 'block';
        document.getElementById('createAnchor').style.display = 'none';
        document.getElementById('logoutAnchor').style.display = 'none';
    }
}

async function onLogout(ctx) {
    await logout();
    refreshNavigationBar();
    ctx.page.redirect('/');
}
