function create(words) {
   let outputElement = document.getElementById('content');

   for (let index = 0; index < words.length; index++) {

      let div = document.createElement('div');
      let paragraphElement = document.createElement('p')

      paragraphElement.textContent = words[index];
      paragraphElement.style.display = 'none';
      div.appendChild(paragraphElement);

      div.addEventListener('click', (e) => {
         e.target.children[0].style.display = 'block';
         console.log('changed');
      });

      outputElement.appendChild(div);
   }
}