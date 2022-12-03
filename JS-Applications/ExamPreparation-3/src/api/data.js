import { get, post, put, del } from './api.js';

//methods

export async function getAllOffers() {
    let offers = await get('/data/offers?sortBy=_createdOn%20desc');
    return offers;
}

export async function postOffer(data) {
    let answer = await post('/data/offers', data);
    return answer;
}

export async function getOfferById(id) {
    let offer = await get(`/data/offers/${id}`);
    return offer;
}

export async function editOffer(id, data) {
    let answer = await put(`/data/offers/${id}`, data);
    return answer;
}

export async function deleteOffer(id) {
    let answer = await del(`/data/offers/${id}`);
    return answer;
}