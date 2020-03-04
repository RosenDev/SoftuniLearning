function solve(){
   var rows = Array.from(document.getElementsByTagName("tr"));
   rows.forEach(r=>{
       r.addEventListener("click",function(){
        if(this.hasAttribute("style")){
            this.removeAttribute("style")
            return;
           
            }
           Array.from(this.parentNode.getElementsByTagName("tr"))
           .forEach(r=>{
               r.removeAttribute("style")
           })
           this.setAttribute("style","background-color:#413f5e;") 
           
       })
   })
}
