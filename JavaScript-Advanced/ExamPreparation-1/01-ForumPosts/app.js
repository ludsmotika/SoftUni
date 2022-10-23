window.addEventListener("load", solve);

function solve() {

  document.getElementById("publish-btn").addEventListener('click', createPost);
  document.getElementById("clear-btn").addEventListener('click', clearApprovedPosts);
  let inputTitleElement = document.getElementById("post-title");
  let inputCategoryElement = document.getElementById('post-category');
  let inputContentElement = document.getElementById('post-content');
  let outputElement = document.getElementById('review-list');

  function createPost() {

    if (inputTitleElement.value === '' || inputCategoryElement.value === '' || inputContentElement.value === '') {
      return;
    }

    let elementToPush = document.createElement('li');
    elementToPush.classList.add('rpost');

    let articleElement = document.createElement('article');

    let titleElementToAdd = document.createElement('h4');
    titleElementToAdd.textContent = inputTitleElement.value;

    let categoryElementToAdd = document.createElement('p');
    categoryElementToAdd.textContent = 'Category: ' + inputCategoryElement.value;

    let contentElementToAdd = document.createElement('p');
    contentElementToAdd.textContent = 'Content: ' + inputContentElement.value;

    articleElement.appendChild(titleElementToAdd);
    articleElement.appendChild(categoryElementToAdd);
    articleElement.appendChild(contentElementToAdd);

    let editButtonToAdd = document.createElement('button');
    editButtonToAdd.classList.add('action-btn');
    editButtonToAdd.classList.add('edit');
    editButtonToAdd.textContent = 'Edit';
    editButtonToAdd.addEventListener('click', editPost);

    let approveButtonToAdd = document.createElement('button');
    approveButtonToAdd.classList.add('action-btn');
    approveButtonToAdd.classList.add('approve');
    approveButtonToAdd.textContent = 'Approve';
    approveButtonToAdd.addEventListener('click', approvePost);

    elementToPush.appendChild(articleElement);
    elementToPush.appendChild(editButtonToAdd);
    elementToPush.appendChild(approveButtonToAdd);

    inputTitleElement.value = '';
    inputCategoryElement.value = '';
    inputContentElement.value = '';

    outputElement.appendChild(elementToPush);
  }


  function editPost(e) {

    let postElement = e.target.parentElement;
    let articleElement = postElement.getElementsByTagName('article')[0];
    let title = articleElement.getElementsByTagName('h4')[0].textContent;
    let category = articleElement.getElementsByTagName('p')[0].textContent;
    let content = articleElement.getElementsByTagName('p')[1].textContent;


    inputTitleElement.value = title;
    inputCategoryElement.value = category.split(': ')[1];
    inputContentElement.value = content.split(': ')[1];

    postElement.remove();
  }

  function approvePost(e) {
    let postElement = e.target.parentElement;
    let approvedPostsElement = document.getElementById('published-list');
    approvedPostsElement.appendChild(postElement);
    Array.from(postElement.getElementsByTagName('button')).forEach(btn => btn.remove());
  }

  function clearApprovedPosts() {
    let element = document.getElementById('published-list');
    Array.from(element.getElementsByTagName('li')).forEach(btn => btn.remove());
  }
}
