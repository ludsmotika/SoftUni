
async function attachEvents() {
    let buttonElement = document.getElementById('submit');
    buttonElement.addEventListener('click', await getForecast);
}

async function getForecast() {

    let cityName = document.getElementById('location').value;

    try {
        let p = await fetch('http://localhost:3030/jsonstore/forecaster/locations');
        let data = await p.json();
        let cityCode = data.find(x => x.name === cityName).code;

        const [todayData, upcomingData] = await Promise.all([
            getTodayData(cityCode),
            getUpcommingData(cityCode)
        ]);

        createTodayForecast(todayData);
        createUpcommingForecast(upcomingData);

    } catch (error) {
        document.getElementById("forecast").style.display = "block"
        document.querySelector(".label").textContent = "Error";
        done(error);
    }


}

async function getTodayData(cityCode) {
    let url = `http://localhost:3030/jsonstore/forecaster/today/${cityCode}`
    let p = await fetch(url);
    let data = await p.json();
    return data;
}


async function getUpcommingData(cityCode) {
    let url = `http://localhost:3030/jsonstore/forecaster/upcoming/${cityCode}`;
    let p = await fetch(url);
    let data = await p.json();
    return data;
}

function createTodayForecast(data) {

    const enumIcon = {
        'Sunny': '&#x2600',
        'Partly sunny': '&#x26C5',
        'Overcast': '&#x2601',
        'Rain': '&#x2614',
        'Degrees': '&#176'

    }

    let outputElement = document.getElementById('forecast');

    let currentForecastElement = document.getElementById('current');

    let div = document.createElement('div');
    div.setAttribute('class', 'forecasts');

    let firstSpan = document.createElement('span');
    firstSpan.setAttribute('class', 'condition symbol');
    firstSpan.innerHTML = `${enumIcon[data.forecast.condition]}`;


    let secondSpan = document.createElement('span');
    secondSpan.setAttribute('class', 'condition');

    let nameSpan = document.createElement('span');
    nameSpan.setAttribute('class', 'forecast-data');
    nameSpan.innerHTML = data.name;

    let temperatureSpan = document.createElement('span');
    temperatureSpan.setAttribute('class', 'forecast-data');
    temperatureSpan.innerHTML = `${data.forecast.low}${enumIcon['Degrees']}/${data.forecast.high}${enumIcon['Degrees']}`;

    let conditionSpan = document.createElement('span');
    conditionSpan.setAttribute('class', 'forecast-data');
    conditionSpan.innerHTML = data.forecast.condition;

    secondSpan.appendChild(nameSpan);
    secondSpan.appendChild(temperatureSpan);
    secondSpan.appendChild(conditionSpan);

    div.appendChild(firstSpan);
    div.appendChild(secondSpan);

    currentForecastElement.appendChild(div);
    outputElement.style = 'display:block';

}

function createUpcommingForecast(data) {

    let upcomingForecastElement = document.getElementById('upcoming');

    let div = document.createElement('div');
    div.setAttribute('class', 'forecast-info');

    let firstDaySpan = document.createElement('span');
    let secondDaySpan = document.createElement('span');
    let thirdDaySpan = document.createElement('span');

    createSpanElements(firstDaySpan, data.forecast[0]);
    createSpanElements(secondDaySpan, data.forecast[1]);
    createSpanElements(thirdDaySpan, data.forecast[2]);

    div.appendChild(firstDaySpan);
    div.appendChild(secondDaySpan);
    div.appendChild(thirdDaySpan);

    upcomingForecastElement.appendChild(div);
}


function createSpanElements(daySpan, data) {
    const enumIcon = {
        'Sunny': '&#x2600',
        'Partly sunny': '&#x26C5',
        'Overcast': '&#x2601',
        'Rain': '&#x2614',
        'Degrees': '&#176'

    }

    let currentSymbolSpan = document.createElement('span');
    currentSymbolSpan.setAttribute('class', 'symbol');
    currentSymbolSpan.innerHTML = enumIcon[data.condition];

    let currentTempSpan = document.createElement('span');
    currentTempSpan.setAttribute('class', 'forecast-data');
    currentTempSpan.innerHTML = `${data.low}${enumIcon['Degrees']}/${data.high}${enumIcon['Degrees']}`;

    let currentConditionsSpan = document.createElement('span');
    currentConditionsSpan.setAttribute('class', 'forecast-data');
    currentConditionsSpan.innerHTML = data.condition;

    daySpan.appendChild(currentSymbolSpan);
    daySpan.appendChild(currentTempSpan);
    daySpan.appendChild(currentConditionsSpan);

}


attachEvents();