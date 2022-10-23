function writeInfo(obj){
    console.log(`${typeof(obj)}: ${obj}`);
}


writeInfo('car');
writeInfo(3);
writeInfo(function(){console.log(3);});
writeInfo({name: 'pepi', years: 3});
