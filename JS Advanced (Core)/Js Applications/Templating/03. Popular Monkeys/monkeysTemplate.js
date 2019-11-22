
function toggleVisibility(element){
return element.hasAttribute("style")?
element.removeAttribute("style"):
element.setAttribute("style","display:none");
}

$(async () => {
    
    const clickHandlers={
        "info":function(target){
           let info = target.parentNode.getElementsByTagName("p")[0];
           toggleVisibility(info);

        }
    }
    
 const context = {monkeys:monkeys}
const source =await fetch("./monkeys.hbs")
.then(r=>r.text())
    const template = Handlebars
    .compile(source);
const html = template(context);
document.getElementsByClassName("monkeys")[0].innerHTML=html;

document.addEventListener("click",function(e){
    if(typeof clickHandlers[e.target.getAttribute("class")]==='function')
    {
        clickHandlers[e.target.getAttribute("class")](e.target);
    }
})
})