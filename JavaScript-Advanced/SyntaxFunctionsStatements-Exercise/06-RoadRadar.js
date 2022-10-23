function speedCalculator(speed, zone) {
    let limit = 0;
    if (zone == 'motorway') {
        limit = 130;
    }
    else if (zone == 'interstate') {
        limit = 90;
    }
    else if (zone == 'city') {
        limit = 50;
    }
    else if (zone == 'residential') {
        limit = 20;
    }

    if (speed <= limit) { console.log(`Driving ${speed} km/h in a ${limit} zone`) }
    else {
        let status;
        let difference = speed-limit;
        if (difference <= 20) { status = 'speeding' }
        else if (difference <= 40) { status = 'excessive speeding' }
        else { status = 'reckless driving' }
        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${limit} - ${status}`);
    }
}
