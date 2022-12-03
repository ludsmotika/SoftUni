import { get, post, put, del } from './api.js';

//hello

export async function getAllAlbums() {
    let albums = await get('/data/albums?sortBy=_createdOn%20desc&distinct=name');
    return albums;
}

export async function createAlbum(album) {
    let answer = await post('/data/albums', album);
    return answer;
}

export async function getAlbumById(id) {
    let album = await get(`/data/albums/${id}`);
    return album;
}

export async function removeAlbumFromServer(id) {
    let answer = await del(`/data/albums/${id}`);
    return answer;
}