import { getTopics } from './dbRequests.js';
import { loadPageWithComments } from './commentsOnPost.js'

let topicsElement = document.getElementById('topicsContainer');

export async function showTopics() {

    document.getElementById('topicList').style.display='block';
    topicsElement.innerHTML = '';
    let data = await getTopics();

    for (let currentTopic in data) {
        let div = document.createElement('div');
        div.setAttribute('class', "topic-container");
        div.innerHTML = ` <div class="topic-name-wrapper">
        <div class="topic-name">
            <a href="#" class="normal" id = '${data[currentTopic]._id}'>
                <h2>${data[currentTopic].topicName}</h2>
            </a>
            <div class="columns">
                <div>
                    <p>Date: <time>2020-10-10T12:08:28.451Z</time></p>
                    <div class="nick-name">
                        <p>Username: <span>${data[currentTopic].username}</span></p>
                    </div>
                </div>

 
              </div>
            </div>`;
        div.querySelector('a').addEventListener('click', loadPageWithComments);
        topicsElement.appendChild(div);
    }

    //DocumentFragment
    //render topics
}