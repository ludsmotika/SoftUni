async function solution() {
    let data = await getData('http://localhost:3030/jsonstore/advanced/articles/list');

    for (let current of data) {
        createHTML(current);
    }
}

function createHTML(obj) {
    let mainDiv = document.createElement('div');
    mainDiv.setAttribute('class', 'accordion');

    let stInnerDiv = document.createElement('div');
    stInnerDiv.setAttribute('class', 'head');

    let titleSpan = document.createElement('span');
    titleSpan.textContent = obj.title;

    let moreOrLessButton = document.createElement('button');
    moreOrLessButton.setAttribute('class', 'button');
    moreOrLessButton.setAttribute('id', `${obj._id}`);
    moreOrLessButton.textContent = 'More';
    moreOrLessButton.addEventListener('click', moreLessButtonFunctionality);

    stInnerDiv.appendChild(titleSpan);
    stInnerDiv.appendChild(moreOrLessButton);
    mainDiv.appendChild(stInnerDiv);

    document.getElementById('main').appendChild(mainDiv);
}

async function moreLessButtonFunctionality(e) {

    let currentElement = e.target;
    if (currentElement.textContent == 'More') {
        let responce = await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${currentElement.id}`);
        let data = await responce.json();
        console.log(currentElement.id);
        console.log(data);
        let div = document.createElement('div');
        div.setAttribute('class', 'extra');
        let p = document.createElement('p');
        p.textContent = data.content;
        div.appendChild(p);
        div.style.display='block';

        currentElement.parentElement.parentElement.appendChild(div);
        currentElement.textContent = 'Less';
    }
    else {
        currentElement.parentElement.parentElement.children[1].remove();
        currentElement.textContent = 'More';
    }
}

async function getData(url) {
    let responce = await fetch(url);
    let data = await responce.json();
    return data;
}


solution();