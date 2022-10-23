function solve() {
  let result = '';
  let textToProcess = document.getElementById('text').value.toLowerCase().split(' ');
  let namingConvention = document.getElementById('naming-convention').value;
  if (namingConvention == 'Pascal Case') {
    for (let word of textToProcess) {
      result += word[0].toUpperCase() + word.slice(1);
    }
  }
  else if (namingConvention == 'Camel Case') {
    result += textToProcess[0];
    for (let i = 1; i < textToProcess.length; i++) {
      let word=textToProcess[i]
      result += word[0].toUpperCase() + word.slice(1);
    }
  }
  else {
    result = 'Error!';
  }

  document.getElementById('result').textContent = result;
}