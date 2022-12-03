import { get, post, put, del } from './api.js';

//methods

export async function getAllAlbums() {
    let albums = await get('/data/albums?sortBy=_createdOn%20desc');
    return albums;
}

export async function createAlbum(data) {
    let result = await post('/data/albums', data);
    return result;
}

export async function getAlbumById(id) {
    let album = await get(`/data/albums/${id}`);
    return album;
}

export async function deleteAlbumById(id) {
    let answer = await del(`/data/albums/${id}`);
    return answer;
}

export async function updateAlbum(id, data) {
    let answer = await put(`/data/albums/${id}`, data);
    return answer;
}