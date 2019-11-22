async function loadTownsClickHandler(e){
    const HB = window.Handlebars;
    const template  = await fetch("http://127.0.0.1:5500/towns.hbs")
.then(res=>res.text());

const townNames = document.getElementById("towns").value
.split(", ");
const context={towns:townNames};
const compiledTemplate = HB.compile(template);
const html = compiledTemplate(context);

document.getElementById("root").innerHTML= html;

}

(function(){
document.getElementById("btnLoadTowns")
.addEventListener("click",loadTownsClickHandler);

}())