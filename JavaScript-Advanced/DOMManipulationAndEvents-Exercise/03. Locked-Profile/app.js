function lockedProfile() {
    let buttonElements = document.querySelectorAll('button');
    for (let index = 0; index < buttonElements.length; index++) {
        buttonElements[index].addEventListener('click', (e) => {
            let isUnlocked = e.target.parentElement.querySelectorAll('input[type="radio"]')[1].checked;
            if (isUnlocked) {
                let div = e.target.parentElement.querySelectorAll('div')[0];

                if (buttonElements[index].textContent === 'Show more') {
                    div.style.display = 'block';
                    buttonElements[index].textContent = 'Hide it';
                } else {
                    div.style.display = 'none';
                    buttonElements[index].textContent = 'Show more';
                }

            }

        });
    }

}