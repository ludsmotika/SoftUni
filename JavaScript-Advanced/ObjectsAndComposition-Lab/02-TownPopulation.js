function townPopulation(arr) {
    let result = [];
    for (let element of arr) {

        let info = element.split(' <-> ');

        if (result[info[0]] === undefined) {
            result[info[0]] = Number(info[1]);
        }
        else{
            result[info[0]]+=Number(info[1]);
        }

        
    }
    for (let key in result) {
        console.log(key+` : `+ result[key]);
    }
}

townPopulation(['Sofia <-> 1200000',
'Montana <-> 20000',
'New York <-> 10000000',
'Washington <-> 2345000',
'Las Vegas <-> 1000000']
);