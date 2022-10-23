function createRectangle(width, height, color) {
    
let formatedColor=color[0].toUpperCase()+color.slice(1);

    let rectangle={
        width, 
        height,
        color: formatedColor,
        calcArea: function(){return rectangle.width*rectangle.height;} 
    }
    return rectangle;
 }


 let rect = createRectangle(4, 5, 'red');
 console.log(rect.width);
 console.log(rect.height);
 console.log(rect.color);
 console.log(rect.calcArea());
 