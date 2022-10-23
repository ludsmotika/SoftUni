function search() {
   let towns = document.querySelectorAll('ul li');
   let textToSearchFor = document.getElementById('searchText').value;
   let count=0;
   for (let town of towns) {
      if (town.textContent.indexOf(textToSearchFor) != -1) {
         town.style.fontWeight='bold';
         town.style.textDecoration = "underline";
         count++;
      }
      else{
         town.style.fontWeight='normal';
         town.style.textDecoration = "none"; 
      }
   }
 document.getElementById('result').textContent=`${count} matches found`;
}
