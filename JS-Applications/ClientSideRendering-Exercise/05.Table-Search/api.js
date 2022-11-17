export async function getData() {
    let responce = await fetch('http://localhost:3030/jsonstore/advanced/table');
    let data = await responce.json();
    return data;
}