import { getTopicById, getCommentsForPost, postCommentInDB } from './dbRequests.js'

export async function loadPageWithComments(e) {
    document.getElementById('topicList').style.display = 'none';
    document.getElementById('topicInputSection').style.display = 'none';
    document.getElementById('postWithCommets').style.display = 'block';
    document.getElementById('comment-form').setAttribute('postid', e.target.parentElement.id);

    let postData = await getTopicById(e.target.parentElement.id);

    let divForTopic = document.createElement('div');
    divForTopic.setAttribute('class', 'header');

    divForTopic.innerHTML = `<img src="./static/profile.png" alt="avatar">
    <p><span>${postData.username}</span> posted on <time>2020-10-10 12:08:28</time></p>
    <p class="post-content">${postData.postText}</p>`;


    document.getElementById('currentPostInfo').appendChild(divForTopic);

    await loadEveryCommentOnThisPost(e.target.parentElement.id);

    document.getElementById('comment-form').addEventListener('submit', postComment);
}

async function postComment(e) {
    e.preventDefault();
    let postId = e.target.attributes.postid.nodeValue;
    let form = new FormData(e.target);
    let data = Object.fromEntries(form);
    data['postId'] = postId;
    if (data.username == '' || data.postText == '') {
        return;
    }

    document.getElementById('username').value = '';
    document.getElementById('comment').value = '';

    await postCommentInDB(data);
    await loadEveryCommentOnThisPost(postId);
}

async function loadEveryCommentOnThisPost(id) {
    let fragment = new DocumentFragment();

    let comments = await getCommentsForPost(id);

    for (let current of comments) {
        let div = document.createElement('div');
        div.setAttribute('id', 'user-comment');
        div.innerHTML = ` <div class="topic-name-wrapper">
        <div class="topic-name">
            <p><strong>${current.username}</strong> commented on <time>${current.time}</time></p>
            <div class="post-content">
                <p>${current.postText}</p>
            </div>
        </div>
    </div>`;

        fragment.appendChild(div);
    }
    document.getElementById('currentPostInfo').appendChild(fragment);
}