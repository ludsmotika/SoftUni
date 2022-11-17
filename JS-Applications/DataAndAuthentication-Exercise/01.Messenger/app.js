function attachEvents() {
    let sendButton = document.getElementById('submit');
    let refreshButton = document.getElementById('refresh');

    sendButton.addEventListener('click', onSendingMessage);
    refreshButton.addEventListener('click', onLoading)

}

function onSendingMessage() {

    let authorInput = document.querySelector('input[name="author"]');
    let contentInput = document.querySelector('input[name="content"]');

    if (authorInput.value == '' || contentInput.value == '') {
        return;
    }

    let body = {
        author: authorInput.value,
        content: contentInput.value
    };

    sendMessage(body);

    authorInput.value = '';
    contentInput.value = '';

}

async function onLoading() {

    let messagesToRender = await loadMessages();
    let textArea = document.getElementById('messages');
    textArea.textContent = '';

    let text = '';
    for (let current in messagesToRender) {
        text += `${messagesToRender[current].author}: ${messagesToRender[current].content}\n`;
    }
    textArea.textContent = text.trimEnd();
}


async function sendMessage(obj) {

    await fetch('http://localhost:3030/jsonstore/messenger', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(obj)
    });

}

async function loadMessages() {

    let responce = await fetch('http://localhost:3030/jsonstore/messenger');
    let data = await responce.json();
    return data;
}

attachEvents();