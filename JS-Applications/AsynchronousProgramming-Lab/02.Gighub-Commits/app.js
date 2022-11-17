function loadCommits() {
    let usernameElement = document.getElementById('username');
    let repoNameElement = document.getElementById('repo');

    fetch(`https://api.github.com/repos/${usernameElement.value}/${repoNameElement.value}/commits`)
        .then(result => {
            if (result.status != 200) {
                throw new Error(`${result.status}`);
            }
            return result.json();
        })
        .then(data => handleData(data))
        .catch(error => handleError(error));

}

function handleData(data) {
    let outputElement = document.getElementById('commits');
    for (let current of data) {
        let li = document.createElement('li');
        li.textContent = `${current.commit.author.name}: ${current.commit.message}`;
        outputElement.appendChild(li);
    }
}

function handleError(error) {
    let outputElement = document.getElementById('commits');
    let li = document.createElement('li');
    li.textContent = `Error: ${error.message} (Not Found)`;
    outputElement.appendChild(li);
}