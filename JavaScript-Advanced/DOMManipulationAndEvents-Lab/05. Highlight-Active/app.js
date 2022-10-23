function focused() {
    let textElements=document.getElementsByTagName('input');
    console.log(textElements.length);
    for (let row of textElements) {
        row.addEventListener('focus', ()=>{
            row.parentElement.classList.add('focused');
        });
        
        row.addEventListener('blur', ()=>{
            row.parentElement.classList.remove('focused');
        });
    }
}