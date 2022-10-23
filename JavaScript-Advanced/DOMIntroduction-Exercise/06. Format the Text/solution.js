function solve() {

  let inputText = document.getElementById('input').value;
  let resultArr = inputText.split('.').filter(x => x.length > 0);

  let result = '';

  let outputDivElement = document.getElementById('output');

  while (resultArr.length > 0) {
    let paragraphSentences = resultArr.splice(0, 3).join('.') + '.';
    result += paragraphSentences;
    let p = document.createElement('p');
    p.textContent = paragraphSentences;
    outputDivElement.appendChild(p);
  }
}