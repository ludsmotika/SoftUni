import { get, post, put, del } from "./api.js";

export async function getAllPets() {
    return await get('/data/pets?sortBy=_createdOn%20desc&distinct=name');
}

export async function getPetById(id) {
    return await get(`/data/pets/${id}`);
}

export async function addPetToCatalog(data) {
    return await post('/data/pets', data);
}

export async function updateCat(id, data) {
    return await put(`/data/pets/${id}`, data);
}

export async function deleteCat(id) {
    return await del(`/data/pets/${id}`);
}
