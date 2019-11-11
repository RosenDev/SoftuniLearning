function solve(params) 
{
   const addButtons =  Array.from(document.getElementsByClassName("add-product"));
   const checkoutBtn =  document.getElementsByClassName("checkout")[0];
   const selectedArea = document.getElementsByTagName("textarea")[0]; 
   const cart=[];
   let totalPrice= 0;

   function addButtonClickHandler(evt)
   {
      let btn = evt.target;
      
      let productDetails = btn.parentNode
      .parentNode.getElementsByClassName("product-details")[0];

      let product = {"title":productDetails
      .getElementsByClassName("product-title")[0]
      .innerHTML,"price":Number(productDetails.parentNode
      .getElementsByClassName("product-line-price")[0]
      .innerHTML)}
      
      cart.push(product);
    
      outputResultLine(selectedArea, 
         getAddOutputMessage(product.title,product.price));

   }

   function outputResult(outputTarget,result)
   {
     outputTarget.value+=result;
     return outputTarget.value;
   }
function checkoutButtonClickHandler(e)
{
outputResultLine(selectedArea,getCheckoutOutputMessage(cart));

addButtons.forEach(b=>{
   b.disabled=true;
})

e.target.disabled=true;
}

   function outputResultLine(outputTarget,result)
   {

    outputTarget.value+=result+"\n";
   
    return outputTarget.value;
     }

   checkoutBtn.addEventListener("click",checkoutButtonClickHandler);
   
   
   addButtons.forEach(btn=>{
      btn.addEventListener("click",addButtonClickHandler)
   })

   function getAddOutputMessage(productName,productPrice)
   {
      return `Added ${productName} for ${productPrice.toFixed(2)} to the cart.`;
   }

   function getCheckoutOutputMessage(products)
   {

      let productNames = [...new Set(products.map(x=>x["title"]))]

     totalPrice = products
     .map(p=>p["price"])
     .reduce((a,b)=>a+b)

     return `You bought ${productNames.join(", ")} for ${totalPrice.toFixed(2)}.`;

   }
}
