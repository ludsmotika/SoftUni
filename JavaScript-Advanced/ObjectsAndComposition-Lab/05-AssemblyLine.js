function createAssemblyLine() {

    let assemblyLine= {
    hasClima: function (car) {
        car.temp = 21,
            car.tempSettings = 21,
            car.adjustTemp = function () {
                if (car.temp < car.tempSettings) {
                    car.temp++;
                }
                else {
                    car.temp--;
                }
            }
    },

    hasAudio: function (car) {
        car.currentTrack = null,
            car.nowPlaying = function () {
                if (car.currentTrack !== null) {
                    console.log(`Now playing '${car.currentTrack.name}' by ${car.currentTrack.artist}`);
                }
            }
    },


    hasParktronic: function (car) {
        car.checkDistance = function (number) {
            if (number < 0.1) {
                console.log("Beep! Beep! Beep!");
            }
            else if (number < 0.25) {
                console.log("Beep! Beep!");
            }
            else if (number < 0.5) {
                console.log("Beep!");
            }
            else{console.log("")}
        }
    }
 }
 return assemblyLine;
}


const assemblyLine = createAssemblyLine();

const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};
