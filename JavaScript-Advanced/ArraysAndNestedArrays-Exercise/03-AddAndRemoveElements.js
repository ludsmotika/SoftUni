function addAndRemove(array) {
    let arr = [];
    for (let index = 0; index < array.length; index++) {

        if (array[index] == 'add') { arr.push(index + 1); }
        else { arr.pop(); }
    }
    if (arr.length == 0) { console.log("Empty") }
    else {
        console.log(arr.join('\n'));
    }
}

addAndRemove(['add',
    'add',
    'remove',
    'add',
    'add']

)