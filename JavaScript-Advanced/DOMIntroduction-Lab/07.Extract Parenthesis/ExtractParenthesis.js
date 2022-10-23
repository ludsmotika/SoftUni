function extract(content) {
    let element = document.getElementById(content);
    let elementText = document.getElementById(content).textContent;
    let result = '';
    for (let i = 0; i < elementText.length; i++) {

        if (elementText[i] === '(') {

            for (let k = i + 1; k < elementText.length; k++) {
                if (elementText[k] !== ')') {
                    result += elementText[k];
                }
                else {
                    result += '; ';
                    i = k;
                    break;
                }

            }

        }

    }

   return result.slice(0,result.length-2);
}