import { towns } from './towns.js'
import { html, render, nothing } from '../node_modules/lit-html/lit-html.js'



let te = 'text';
let er = 'te';
console.log(te.substring(0, er.length));

let showTowns = (towns, textToContain) => html` <ul>
${towns.map(town => html`<li class=${town.includes(textToContain) ? 'active' : nothing}> ${town}</li > `)}
</ul>`;


render(showTowns(towns), document.getElementById('towns'));

document.querySelector('button').addEventListener('click', search);

function search() {
   let textToContain = document.getElementById('searchText').value;
   render(showTowns(towns, textToContain), document.getElementById('towns'));
   document.getElementById('result').textContent = `${occurrences(document.getElementById('towns').innerHTML, 'active', false)} matches found`;
}


function occurrences(string, subString, allowOverlapping) {

   string += "";
   subString += "";
   if (subString.length <= 0) return (string.length + 1);

   var n = 0,
      pos = 0,
      step = allowOverlapping ? 1 : subString.length;

   while (true) {
      pos = string.indexOf(subString, pos);
      if (pos >= 0) {
         ++n;
         pos += step;
      } else break;
   }
   return n;
}