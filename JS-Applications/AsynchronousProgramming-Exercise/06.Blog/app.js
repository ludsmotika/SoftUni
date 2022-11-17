function attachEvents() {
    
    let loadButton = document.getElementById('btnLoadPosts');
    loadButton.addEventListener('click', loadPosts);

    let viewButton = document.getElementById('btnViewPost');
    viewButton.addEventListener('click', viewPostInfo);


    function loadPosts() {
        document.getElementById('posts').innerHTML = '';

        fetch('http://localhost:3030/jsonstore/blog/posts')
            .then(responce => responce.json())
            .catch(er => { alert('Error') })
            .then(data => createOptions(data));
    }


    function viewPostInfo() {

        document.getElementById('post-comments').innerHTML = '';

        let idOfWantedPost = document.getElementById('posts').value;

        fetch('http://localhost:3030/jsonstore/blog/posts/' + idOfWantedPost).then(responce => responce.json()).catch(er => alert('Error')).then(postInfo => {
            document.getElementById('post-title').textContent = postInfo.title;
            document.getElementById('post-body').textContent = postInfo.body;
        })

        clearComments();

        fetch('http://localhost:3030/jsonstore/blog/comments').then(responce => responce.json()).catch(er => alert('Error')).then(commentsInfo => {
            for (let current in commentsInfo) {
                if (commentsInfo[current].postId === idOfWantedPost) {
                    createComment(commentsInfo[current]);
                }
            }
        });
    }

    function clearComments() {

        let commentsElement = document.getElementById('post-comments');
        commentsElement.innerHTML = '';

    }

    function createComment(data) {

        let li = document.createElement('li');
        li.setAttribute('id', data.id);
        li.textContent = data.text;
        document.getElementById('post-comments').appendChild(li);

    }

    function createOptions(data) {

        let listWithPosts = document.getElementById('posts');

        for (let current in data) {
            let option = document.createElement('option');
            option.setAttribute('value', `${current}`);
            option.textContent = `${data[current].title}`;
            listWithPosts.appendChild(option);
        }

    }
}


attachEvents();
