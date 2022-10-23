function attachGradientEvents() {
    let gradientBox = document.getElementById('gradient');
    let resultElement = document.getElementById('result');

    gradientBox.addEventListener('mousemove', (event) => {
        let maxWidth = event.target.offsetWidth;
        let percentage=Math.trunc((event.offsetX/(event.target.clientWidth - 1))*100);
        resultElement.textContent=`${percentage}%`;


    });

    const gradientMouseOutHandler = (e) => {
        resultElement.textContent = '';
    };
    gradientBox.addEventListener('mouseout', gradientMouseOutHandler);

}


