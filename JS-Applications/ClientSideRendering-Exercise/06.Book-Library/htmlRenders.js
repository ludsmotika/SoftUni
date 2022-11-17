import { html } from '../node_modules/lit-html/lit-html.js';
import { showEditPage, deleteRow, addRow, updateRow } from './app.js';


let showTable = (row) => html`<tr>
<td>${row.title}</td>
<td>${row.author}</td>
<td>
    <button id='${row.id}' @click=${showEditPage}>Edit</button>
    <button id='${row.id}' @click=${deleteRow}>Delete</button>
</td>
</tr>`;


let showAddMenu = () => html`<h3>Add book</h3>
<label>TITLE</label>
<input id='titleInput' type="text" name="title" placeholder="Title...">
<label>AUTHOR</label>
<input id='authorInput' type="text" name="author" placeholder="Author...">
<input type="submit" @click=${addRow} value="Submit">`;


let showEditMenu = (data) => html` <input type="hidden" name="id">
<h3>Edit book</h3>
<label>TITLE</label>
<input id='titleInput' type="text" name="title" value=${data.title} placeholder="Title...">
<label>AUTHOR</label>
<input id='authorInput' type="text" name="author" value=${data.author} placeholder="Author...">
<input type="submit" id='${data._id}' @click=${updateRow} value="Save">`;


export { showTable, showAddMenu, showEditMenu };