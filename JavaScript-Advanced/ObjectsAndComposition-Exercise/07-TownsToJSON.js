function townsToJSON(input) {
    let answer = [];
    for (let index = 1; index < input.length; index++) {
        let current = input[index].split(new RegExp(/\s*\|\s*/)).filter(Boolean);
        answer.push({
            Town: current[0],
            Latitude: Number(Number(current[1]).toFixed(2)),
            Longitude: Number(Number(current[2]).toFixed(2))
        });
    }
    return JSON.stringify(answer);
}

townsToJSON(['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
);