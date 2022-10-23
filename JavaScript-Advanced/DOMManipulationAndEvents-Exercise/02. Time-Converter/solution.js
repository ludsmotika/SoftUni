function attachEventsListeners() {
    let buttons = document.querySelectorAll('input[type="button"]');
    let inputElements = document.querySelectorAll('input[type="text"]');
    for (let index = 0; index < buttons.length; index++) {
        buttons[index].addEventListener('click', (e) => {
            let number = e.target.parentElement.querySelector('input[type="text"]').value;
            let type = e.target.parentElement.querySelector('input[type="text"]').id;
            let data = returnData(number, type);
            inputElements[0].value = data.days;
            inputElements[1].value = data.hours;
            inputElements[2].value = data.minutes;
            inputElements[3].value = data.seconds;
        })
    }

    function returnData(inputNumber, inputType) {
        let data = {};

        switch (inputType) {
            case 'days':
                data.days=inputNumber;
                data.hours = inputNumber * 24;
                data.minutes = inputNumber * 24 * 60;
                data.seconds = inputNumber * 24 * 60 * 60;
                break;
            case 'hours':
                data.days = inputNumber / 24;
                data.hours=inputNumber;
                data.minutes = inputNumber * 60;
                data.seconds = inputNumber * 60 * 60;
                break;
            case 'minutes':
                data.days = inputNumber / 60 / 24;
                data.hours = inputNumber / 60;
                data.minutes=inputNumber;
                data.seconds = inputNumber * 60;
                break;
            case 'seconds':
                data.days = inputNumber / 60 / 60 / 24;
                data.hours = inputNumber / 60 / 60;
                data.minutes = inputNumber / 60;
                data.seconds=inputNumber;
                break;
        }
        return data;
    }
}