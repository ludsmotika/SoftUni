export async function getTopics() {
    let res = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts');
    let data = await res.json();
    return data;
}

export async function getTopicById(id) {
    let res = await fetch(`http://localhost:3030/jsonstore/collections/myboard/posts/${id}`);
    let data = await res.json();
    return data;
}

export async function postTopic(topicData) {
    let res = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(topicData)
    });

    if (res.status != '200') {
        return;
    }

    let data = await res.json();
    return data;
}

export async function getCommentsForPost(id) {
    let res = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments');
    let allComments = await res.json();
    let commentsToReturn = [];
    for (let key in allComments) {
        if (allComments[key].postId == id) {
            commentsToReturn.push(allComments[key]);
        }
    }

    return commentsToReturn;
}

export async function postCommentInDB(data) {
    let res = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    });
    let answer = await res.json();
    return answer;
}