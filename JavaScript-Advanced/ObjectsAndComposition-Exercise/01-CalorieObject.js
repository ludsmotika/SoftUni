function getCaloriesTable(products){
    let result={};
    for (let index = 0; index < products.length; index+=2) {
        result[products[index]]=Number(products[[index+1]]);
    }
    console.log(result);
}

getCaloriesTable(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);