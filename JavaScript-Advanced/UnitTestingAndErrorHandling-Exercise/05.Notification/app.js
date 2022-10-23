function notify(message) {
  let divElement = document.getElementById('notification');

  divElement.addEventListener('click', () => {
    divElement.style.display = 'none';
  });

  divElement.textContent = message;
  divElement.style.display = 'block';

}