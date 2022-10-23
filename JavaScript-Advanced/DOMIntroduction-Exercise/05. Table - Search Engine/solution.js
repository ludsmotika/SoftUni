function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let rows = document.querySelectorAll("tbody tr");
      let inputField=document.getElementById('searchField');
      let texttoSearchFor = inputField.value;
      inputField.value="";

      console.log(texttoSearchFor);
if(texttoSearchFor==''){
      for (let row of rows) {
         row.classList.remove('select');
      }
      return;
   }


      for (let row of rows) {

         for (let cell of row.querySelectorAll('td')) {
            if (cell.textContent.toLowerCase().indexOf(texttoSearchFor.toLowerCase()) !== -1) {
               row.classList.add('select');
               break;
            }
         }
      }

   }
}