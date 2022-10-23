function validate() {
    let reguralExpresion = new RegExp('[a-z]+@[a-z]+\.[a-z]+');
    let inputElement = document.getElementById('email');
    inputElement.addEventListener('change', () => {
        if (reguralExpresion.test(inputElement.value)) {
            inputElement.classList.remove('error');
        }
        else {
            inputElement.classList.add('error');
        }
    })
}