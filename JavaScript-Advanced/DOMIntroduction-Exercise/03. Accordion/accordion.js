function toggle() {
    let buttonInfo = document.getElementsByClassName('button')[0].textContent;
    let divElement=document.getElementById('extra');
    if (buttonInfo == 'More') {
divElement.style.display='block';
document.getElementsByClassName('button')[0].textContent='Less';
    }
    else {
        divElement.style.display='none';
        document.getElementsByClassName('button')[0].textContent='More';
     }
}