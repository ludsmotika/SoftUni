import { logout } from './api/api.js';
import { deleteCat } from './api/data.js';
import { getUserData } from './api/util.js';
import { page, render } from './library.js';
import { showCatalog } from './views/catalog.js';
import { showCreate } from './views/create.js';
import { showDetails } from './views/details.js';
import { showEdit } from './views/edit.js';
import { showHome } from './views/home.js';
import { showLogin } from './views/login.js';
import { showRegister } from './views/register.js';

let mainElement = document.getElementById('content');

page(decorateContext);
page('/', showHome)
page('/register', showRegister);
page('/login', showLogin);
page('/logout', onLogout);
page('/catalog', showCatalog);
page('/details/:id', showDetails); 
page('/edit/:id', showEdit);
page('/create', showCreate);
page('/delete/:id', onDelete);

page.start();

refreshNavBar();
page.redirect('/')

function decorateContext(ctx, next) {
    ctx.render = (content) => render(content, mainElement);
    ctx.refreshNavBar = () => refreshNavBar();
    next();
}

async function refreshNavBar() {
    let userData = await getUserData();
    if (userData) {
        document.getElementById('registerAnchor').style.display = 'none';
        document.getElementById('loginAnchor').style.display = 'none';
        document.getElementById('createAnchor').style.display = 'block';
        document.getElementById('logoutAnchor').style.display = 'block';
    } else {
        document.getElementById('registerAnchor').style.display = 'block';
        document.getElementById('loginAnchor').style.display = 'block';
        document.getElementById('createAnchor').style.display = 'none';
        document.getElementById('logoutAnchor').style.display = 'none';
    }
}

async function onLogout() {
    await logout();
    page.redirect('/');
    refreshNavBar();
}

async function onDelete(ctx){
    await deleteCat(ctx.params.id);
    ctx.page.redirect('/');
}