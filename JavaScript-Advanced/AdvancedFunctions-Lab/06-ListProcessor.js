function solution(commands) {
    let commander = currentCommand();

    commands.map((x) => x.split(' ')).forEach(([command, value]) => commander[command](value));

    function currentCommand() {
        let arr = [];
        return {
            add: (text) => { arr.push(text); },
            remove: (text) => { while(arr.includes(text)) { arr.splice(arr.indexOf(text), 1); } },
            print: () => { console.log(arr.join(',')) }
        }
    }

}
solution(['add pesho', 'add george', 'add peter', 'remove peter', 'print']);