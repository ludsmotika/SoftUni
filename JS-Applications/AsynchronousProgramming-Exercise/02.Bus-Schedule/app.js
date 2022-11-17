function solve() {

    let nextStationId = 'depot';
    let currentStationName = '';
    let outputElement = document.getElementById('info').children[0];
    let departButton = document.getElementById('depart');
    let arriveButton = document.getElementById('arrive');


    function depart() {
        fetch(`http://localhost:3030/jsonstore/bus/schedule/${nextStationId}`)
            .then(response => response.json())
            .then(data => handleData(data))
            .catch(err => handleError(err));

        departButton.disabled = true;
        arriveButton.disabled = false;

        function handleData(data) {
            outputElement.textContent = `Next stop ${data.name}`;
            nextStationId = data.next;
            currentStationName = data.name;
        }

        function handleError(err) {
            outputElement.textContent = 'Error';
            departButton.disabled = true;
            arriveButton.disabled = true;
        }
    }

    function arrive() {
        outputElement.textContent = `Arriving at ${currentStationName}`;
        departButton.disabled = false;
        arriveButton.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();