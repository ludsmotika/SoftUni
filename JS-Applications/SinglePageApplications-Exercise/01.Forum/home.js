import { postTopic } from './dbRequests.js'

export function showHome() {
    let topicInputSection = document.getElementById('topicInputSection');
    topicInputSection.style.display = 'block';
}

export async function addTopic(e) {
    e.preventDefault();

    //validation
    let topicData = {
        topicName: document.getElementById('topicName').value,
        username: document.getElementById('username').value,
        postText: document.getElementById('postText').value
    };

    for (let field in topicData) {
        if (topicData[field] == '') {
            return;
        }
    }

    await postTopic(topicData);

    //cannot invoke clear home because of the preventDefault function;
    document.getElementById('topicName').value = '';
    document.getElementById('username').value = '';
    document.getElementById('postText').value = '';
}

export function clearHome(e) {

    e.preventDefault();
    document.getElementById('topicName').value = '';
    document.getElementById('username').value = '';
    document.getElementById('postText').value = '';
}