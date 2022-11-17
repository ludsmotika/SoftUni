function getInfo() {
    let inputElement = document.getElementById('stopId');

    fetch(`http://localhost:3030/jsonstore/bus/businfo/${inputElement.value}`)
        .then(response => response.json())
        .then(data => handleData(data))
        .catch(handleError);




    function handleData(data) {
        document.getElementById('stopName').textContent = data.name;
        let scheduleElement = document.getElementById('buses');
        scheduleElement.innerHTML = '';
        for (let key in data.buses) {
            let li = document.createElement('li');
            li.textContent = `Bus ${key} arrives in ${data.buses[key]} minutes`;
            scheduleElement.appendChild(li);
        }
    }

    function handleError() {
        let scheduleElement = document.getElementById('buses');
        scheduleElement.innerHTML = '';
        document.getElementById('stopName').textContent = 'Error';
    }
}
