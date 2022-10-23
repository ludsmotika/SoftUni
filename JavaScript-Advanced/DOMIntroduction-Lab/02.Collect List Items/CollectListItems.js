function extractText() {
    let outputElement= document.getElementById(`result`);
    let arr=document.querySelectorAll('ul li');
    for (let element of arr) {
     outputElement.textContent+=element.textContent+'\n';  
    }
}