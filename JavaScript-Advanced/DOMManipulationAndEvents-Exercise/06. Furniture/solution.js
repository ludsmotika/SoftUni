function solve() {
  let buttons = document.querySelectorAll('button');
  buttons[0].addEventListener('click', generate)
  buttons[1].addEventListener('click', buy);

  function generate() {
    let InputTextArea = document.querySelectorAll('textarea')[0];
    let itemsToAdd = JSON.parse(InputTextArea.value);
    let tableBody = document.querySelectorAll('tbody')[0];
    for (let index = 0; index < itemsToAdd.length; index++) {
      let currentElement = document.createElement('tr');
      currentElement.innerHTML = `<td><img src=${itemsToAdd[index].img}></td><td><p>${itemsToAdd[index].name}</p></td><td><p>${itemsToAdd[index].price}</p></td><td><p>${itemsToAdd[index].decFactor}</p></td><td><input type="checkbox"/></td>`;
      tableBody.appendChild(currentElement);
    }
  }

  function buy() {
    let table = document.querySelectorAll('tbody')[0];
    let sum = 0;
    let products = [];
    let decorationFactorSum = 0;
    for (let row of table.children) {
      if (row.querySelectorAll('input[type="checkbox"]')[0].checked == true) {
        let paragraphs = row.querySelectorAll('p');
        products.push(paragraphs[0].textContent);
        sum += Number(paragraphs[1].textContent);
        decorationFactorSum+=Number(paragraphs[2].textContent);
      }
    }
    let result=`Bought furniture: ${products.join(', ')}\nTotal price: ${sum.toFixed(2)}\nAverage decoration factor: ${decorationFactorSum/products.length}`;
    document.querySelectorAll('textarea')[1].innerText=result;

  }
}