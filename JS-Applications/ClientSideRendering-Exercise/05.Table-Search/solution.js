import { html, render, nothing } from '../node_modules/lit-html/lit-html.js';
import { getData } from './api.js';

solve();
let outputElement = document.querySelector('tbody');

let rowCard = (row, toMatch) => html`<tr class=${containsText(row, toMatch) ? 'select' : nothing}>
<th>${row.fullName}</th>
<th>${row.email}</th>
<th>${row.course}</th>
</tr>`;

function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);
   onClick();

   async function onClick() {
      let data = await getData();

      let dataList = [];

      for (let key in data) {
         dataList.push({
            fullName: data[key].firstName + ' ' + data[key].lastName,
            email: data[key].email,
            course: data[key].course
         });
      }

      let toMatch = document.getElementById('searchField').value;
      document.getElementById('searchField').value = '';

      render(dataList.map(item => rowCard(item, toMatch)), outputElement);
   }
}


function containsText(row, toMatch) {

   if (toMatch != '' && (row.fullName.toLowerCase().includes(toMatch.toLowerCase()) || row.email.toLowerCase().includes(toMatch.toLowerCase()) || row.course.toLowerCase().includes(toMatch.toLowerCase()))) {
      return true;
   }
   return false;

}