window.addEventListener("load", solve);

function solve() {
  let publishButtonElement = document.getElementById('form-btn');
  let firstNameInputElement = document.getElementById('first-name');
  let lastNameInputElement = document.getElementById('last-name');
  let ageInputElement = document.getElementById('age');
  let storyTitleInputElement = document.getElementById('story-title');
  let genreInputElement = document.getElementById('genre');
  let storyTextInputElement = document.getElementById('story');
  let previewList = document.getElementById('preview-list');

  publishButtonElement.addEventListener('click', publish);


  function publish() {

    let firstName = firstNameInputElement.value;
    let lastName = lastNameInputElement.value;
    let age = ageInputElement.value;
    let storyTitle = storyTitleInputElement.value;
    let genre = genreInputElement.value;
    let storyText = storyTextInputElement.value;

    //validation

    if (firstName === '' || lastName === '' || age === '' || storyTitle === '' || genre === '' || storyText === '' || isNaN(age) || Number(age) < 0) {
      throw new Error('Invalid input!');
    }

    let toAdd = document.createElement('li');
    toAdd.setAttribute('class', 'story-info');

    let articleElement = document.createElement('article');

    let nameElement = document.createElement('h4');
    nameElement.textContent = `Name: ${firstName} ${lastName}`;

    let ageElement = document.createElement('p');
    ageElement.textContent = `Age: ${age}`;

    let titleElement = document.createElement('p');
    titleElement.textContent = `Title: ${storyTitle}`;

    let genreElement = document.createElement('p');
    genreElement.textContent = `Genre: ${genre}`;

    let storyElement = document.createElement('p');
    storyElement.textContent = `${storyText}`;


    articleElement.appendChild(nameElement);
    articleElement.appendChild(ageElement);
    articleElement.appendChild(titleElement);
    articleElement.appendChild(genreElement);
    articleElement.appendChild(storyElement);

    let saveButton = document.createElement('button');
    saveButton.setAttribute('class', 'save-btn');
    saveButton.textContent = 'Save Story';
    saveButton.addEventListener('click', save);


    let editButton = document.createElement('button');
    editButton.setAttribute('class', 'edit-btn');
    editButton.textContent = 'Edit Story';
    editButton.addEventListener('click', edit);


    let deleteButton = document.createElement('button');
    deleteButton.setAttribute('class', 'delete-btn');
    deleteButton.textContent = 'Delete Story';
    deleteButton.addEventListener('click', deleteStory);

    toAdd.appendChild(articleElement);
    toAdd.appendChild(saveButton);
    toAdd.appendChild(editButton);
    toAdd.appendChild(deleteButton);
    previewList.appendChild(toAdd);


    firstNameInputElement.value = '';
    lastNameInputElement.value = '';
    ageInputElement.value = '';
    storyTitleInputElement.value = '';
    genreInputElement.value = '';
    storyTextInputElement.value = '';


    publishButtonElement.disabled = true;

  }

  function save() {
    let mainElement = document.getElementById('main');
    //check if there is a problem with using innerHTML
    mainElement.innerHTML = '';
    let h1 = document.createElement('h1');
    h1.textContent = "Your scary story is saved!";
    mainElement.appendChild(h1);
  }


  function edit(e) {
    let currentStory = e.target.parentElement;

    let currentName = currentStory.children[0].children[0].textContent.substring(6);
    let currentAge = currentStory.children[0].children[1].textContent.substring(5);
    let currentStoryTitle = currentStory.children[0].children[2].textContent.substring(7);
    let currentGenre = currentStory.children[0].children[3].textContent.substring(7);
    let currentstoryText = currentStory.children[0].children[4].textContent;

    currentName = currentName.split(' ');

    firstNameInputElement.value = currentName[0];
    lastNameInputElement.value = currentName[1];
    ageInputElement.value = currentAge;
    storyTitleInputElement.value = currentStoryTitle;
    genreInputElement.value = currentGenre;
    storyTextInputElement.value = currentstoryText;

    currentStory.remove();
    publishButtonElement.disabled = false;

  }


  function deleteStory(e) {
    let currentStory = e.target.parentElement;
    currentStory.remove();
    publishButtonElement.disabled = false;
  }
}
