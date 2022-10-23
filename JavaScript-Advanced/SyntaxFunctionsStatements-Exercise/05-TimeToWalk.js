function CalculateTimeToSchool(steps, footLength, speed) {
    let s = (steps * footLength) / 1000;
    let t = s / speed;
    let additionalMinutes = Math.floor(s * 1000 / 500);
    let totalSeconds = (t * 60 * 60).toFixed(0);
    totalSeconds = Number(totalSeconds) + additionalMinutes * 60;
    let hours = Math.floor(t);
    let minutes = Math.floor(totalSeconds / 60);
    let seconds = Number(totalSeconds) % 60;
    if (hours < 10) { hours = '0' + hours }
    if (minutes < 10) { minutes = '0' + minutes }
    if (seconds < 10) { seconds = '0' + seconds }
    console.log(`${hours}:${minutes}:${seconds}`);
}