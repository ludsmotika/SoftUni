function transferToJson(array) {
    let result = [];

    for (let index = 0; index < array.length; index++) {

        let current = {};

        let info = array[index].split(" / ");

        current.name = info[0];
        current.level = Number(info[1]);
        current.items = info[2] ? info[2].split(', ') : [];

        result.push(current);
    }

    return JSON.stringify(result);
}

transferToJson(['Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara']);