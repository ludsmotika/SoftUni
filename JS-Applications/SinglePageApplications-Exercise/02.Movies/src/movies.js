import { get } from './api.js';


export async function loadMovies() {
    let moviesList = document.getElementById('movies-list');
    moviesList.innerHTML = '';
    document.getElementById('movie').style.display = 'block';

    let movies = await get('/data/movies');
    let fragment = new DocumentFragment();
    for (let current of movies) {
        const element = document.createElement('div');
        element.className = 'card mb-4';
        element.innerHTML += `
        <img class="card-img-top" src="${current.img}"
            alt="Card image cap" width="400">
        <div class="card-body">
            <h4 class="card-title">${current.title}</h4>
        </div>
        <div class="card-footer">
            <a>
                <button data-id="${current._id}" type="button" class="btn btn-info">Details</button>
            </a>
        </div>`;
        fragment.appendChild(element);
    }
    moviesList.appendChild(fragment);
}