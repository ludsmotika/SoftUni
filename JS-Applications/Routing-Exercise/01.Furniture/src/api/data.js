import { get, post, put, del } from './api.js';


export async function getAllFurniture() {
    return await get('/data/catalog');
}

export async function postFurniture(data) {
    return await post('/data/catalog', data);
}

export async function furnitureDetails(id) {
    return await get(`/data/catalog/${id}`);
}

export async function updateFurniture(data, id) {
    return await put(`/data/catalog/${id}`, data);
}

export async function deleteFurniture(id) {
    return await del(`/data/catalog/${id}`);
}

export async function getMyFurniture(userId) {
    return await get(`/data/catalog?where=_ownerId%3D%22${userId}%22`);
}