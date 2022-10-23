function numberedNames(arr){
    arr.sort((a, b) => a.localeCompare(b));
    for (let index = 1; index <= arr.length; index++) {
        console.log(`${index}.`+arr[index-1])
    }
}

numberedNames(["John", "Bob", "Christina", "Ema"]);