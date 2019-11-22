function toggleView(viewElement)
{
   return viewElement
   .hasAttribute("style") ? viewElement
   .removeAttribute("style") : viewElement
   .setAttribute("style","display:none");
}

(function() {
     renderCatTemplate();

     async function renderCatTemplate() {
         const HB = window.Handlebars;
         const plainPartialTemplate = await fetch("http://localhost:5500/cat.hbs")
         .then(res=>res.text());
         const plainTemplate = await fetch("http://localhost:5500/cats.hbs")
         .then(res=>res.text());
         HB.registerPartial("cat",plainPartialTemplate);
         const template =  HB.compile(plainTemplate);
        const ctx = {cats:window.cats};
         const html =  template(ctx);
         document.getElementById("allCats").innerHTML=html;
        Array.from(document.getElementsByClassName("showBtn"))
        .forEach(btn=>{
            btn.addEventListener("click",function(e){
              toggleView(e.target.parentNode.getElementsByClassName("status")[0])
            })
        });
        
     }
 
}())
