function encodeAndDecodeMessages() {
    let buttonElements = document.querySelectorAll('button');

    buttonElements[0].addEventListener('click', (e) => {
        let encodeTextAreaElement = e.target.parentElement.querySelectorAll('textarea')[0];
        let text = encodeTextAreaElement.value;
        let result = '';
        for (let index = 0; index < text.length; index++) {
            let code = text[index].charCodeAt(0);
            result+= String.fromCharCode(code + 1);
        }
        let decodeTextAreaElement = e.target.parentElement.parentElement.querySelectorAll('textarea')[1];
        decodeTextAreaElement.value=result;
        encodeTextAreaElement.value='';
    });

    buttonElements[1].addEventListener('click', (e) => {
        let decodeTextAreaElement = e.target.parentElement.querySelectorAll('textarea')[0];
        let text = decodeTextAreaElement.value;

        let result = '';
        for (let index = 0; index < text.length; index++) {
            let code = text[index].charCodeAt(0);
            result+= String.fromCharCode(code - 1);
        }
        decodeTextAreaElement.value=result;
    });
}