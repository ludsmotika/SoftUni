async function lockedProfile() {
    let data = await getData('http://localhost:3030/jsonstore/advanced/profiles');

    for (let current in data) {
        createHTML(data[current]);
    }
}

async function getData(url) {
    let response = await fetch(url);
    let data = await response.json();
    return data;
}

function createHTML(current) {

    let mainDiv = document.createElement('div');
    mainDiv.setAttribute('class', 'profile');

    let img = document.createElement('img');
    img.setAttribute('src', "./iconProfile2.png");
    img.setAttribute('class', "userIcon");
    mainDiv.appendChild(img);

    let firstLabel = document.createElement('label');
    firstLabel.textContent = 'Lock';
    mainDiv.appendChild(firstLabel);

    let firstInput = document.createElement('input');
    firstInput.setAttribute('type', 'radio');
    firstInput.setAttribute('name', 'user1Locked');
    firstInput.setAttribute('value', 'lock');
    firstInput.checked = true;
    mainDiv.appendChild(firstInput);

    let secondLabel = document.createElement('label');
    secondLabel.textContent = 'Unlock';
    mainDiv.appendChild(secondLabel);

    let secondInput = document.createElement('input');
    secondInput.setAttribute('type', 'radio');
    secondInput.setAttribute('name', 'user1Locked');
    secondInput.setAttribute('value', 'unlock');
    secondInput.checked = false;
    mainDiv.appendChild(secondInput);

    let thirdLabel = document.createElement('label');
    thirdLabel.textContent = 'Username';
    mainDiv.appendChild(thirdLabel);

    let thirdInput = document.createElement('input');
    thirdInput.setAttribute('type', 'text');
    thirdInput.setAttribute('name', 'user1Username');
    thirdInput.setAttribute('value', `${current.username}`);
    thirdInput.disabled = true;
    thirdInput.readonly = true;
    mainDiv.appendChild(thirdInput);

    let secondDiv = document.createElement('div');
    secondDiv.setAttribute('class', 'user1HiddenFields');
    secondDiv.style.display = 'none';

    let forthLabel = document.createElement('label');
    forthLabel.textContent = 'Email:';
    let emailInput = document.createElement('input');
    emailInput.setAttribute('type', 'email');
    emailInput.setAttribute('name', 'user1Email');
    emailInput.setAttribute('value', `${current.email}`);
    emailInput.disabled = true;
    emailInput.readonly = true;

    let fifthLabel = document.createElement('label');
    fifthLabel.textContent = 'Age:';
    let ageInput = document.createElement('input');
    ageInput.setAttribute('type', 'email');
    ageInput.setAttribute('name', 'user1Age');
    ageInput.setAttribute('value', `${current.age}`);
    ageInput.disabled = true;
    ageInput.readonly = true;

    secondDiv.appendChild(forthLabel);
    secondDiv.appendChild(emailInput);
    secondDiv.appendChild(fifthLabel);
    secondDiv.appendChild(ageInput);

    mainDiv.appendChild(secondDiv);

    let button = document.createElement('button');
    button.textContent = 'Show more';
    button.addEventListener('click', showMore);

    mainDiv.appendChild(button);
    document.getElementById('main').appendChild(mainDiv);
}

function showMore(e) {
    let currentElement = e.target;
    if (currentElement.textContent == 'Show more') {
        if (currentElement.parentElement.children[4].checked == true) {
            currentElement.parentElement.children[7].style.display = 'block';
            currentElement.textContent = 'Hide it';
        }

    }
    else {
        if (currentElement.parentElement.children[2].checked == true) {
            currentElement.disabled = true;
        }
        else {
            currentElement.parentElement.children[7].style.display = 'none';
            currentElement.textContent = 'Show more';
        }
    }
}