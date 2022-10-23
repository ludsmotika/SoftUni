function makeCar(info) {

    let car = {};

    car.model = info[`model`];

    if (info[`power`] <= 90) {
        car.engine = {
            power: 90,
            volume: 1800
        }
    }
    else if (info[`power`] <= 120) {
        car.engine = {
            power: 120,
            volume: 2400
        }
    }
    else {
        car.engine = {
            power: 200,
            volume: 3500
        }
    }

    if (info[`carriage`] === 'coupe') {

        car.carriage = {
            type: `coupe`,
            color: info['color']
        }
    }
    else {
        car.carriage = {
            type: `hatchback`,
            color: info['color']
        }
    }

    let size = info[`wheelsize`];
    let wheelSize = size % 2 == 0 ? size - 1 : size;

    car.wheels= [wheelSize,wheelSize,wheelSize,wheelSize];
    return car;
}

makeCar({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }
);