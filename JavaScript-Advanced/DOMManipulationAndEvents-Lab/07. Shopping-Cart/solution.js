function solve() {
   let buttonElements = document.getElementsByClassName('add-product');
   let textAreaElement = document.getElementsByTagName('textarea')[0];
   let sum = 0;
   let products = [];

   for (let index = 0; index < buttonElements.length; index++) {
      buttonElements[index].addEventListener('click', (event) => {
         let productName = event.target.parentElement.parentElement.children[1].children[0].textContent;
         let productPrice = event.target.parentElement.parentElement.children[3].textContent;
         textAreaElement.textContent += `Added ${productName} for ${productPrice} to the cart.\n`;
         sum += Number(productPrice);
         if (products.indexOf(productName) == -1) {
            products.push(productName);
         }
      });
   }

   let checkoutButton = document.getElementsByClassName('checkout')[0];
   checkoutButton.addEventListener('click', (e) => {
      textAreaElement.textContent += `You bought ${products.join(', ')} for ${sum.toFixed(2)}.`;
      for (let index = 0; index < buttonElements.length; index++) {
         buttonElements[index].disabled = true;
      }
      e.target.disabled = true;
   });
}