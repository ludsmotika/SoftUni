function pies(pies,first ,last){
let firstIndex= pies.indexOf(first);
let lastIndex= pies.indexOf(last);
let selectedPies= pies.slice(firstIndex, lastIndex+1);
return selectedPies;
}
