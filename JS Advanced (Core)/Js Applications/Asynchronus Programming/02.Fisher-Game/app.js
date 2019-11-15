import { initElements } from "./dom.js";
import { CatchService } from "./catch.js";
function attachEvents() {

  const catchService = new CatchService()

  function addBtnHandler(){
    const formData = initElements()
    .addForm();
    let entity={
      "angler":formData.getElementsByClassName("angler")[0].value,
      "weight":formData.getElementsByClassName("weight")[0].value,
      "species":formData.getElementsByClassName("species")[0].value,
      "location":formData.getElementsByClassName("location")[0].value,
      "bait":formData.getElementsByClassName("bait")[0].value,
      "captureTime":formData.getElementsByClassName("captureTime")[0].value
    }
    catchService.add(entity)
    .then(alert("Successfully added new catch"))
    .catch(alert);
  }

  function deleteBtnHandler(e){
    let dataField= e.target.parentNode;
    let id =dataField.getAttribute("data-id")

    catchService.remove(id)
    .then(alert("Successfully updated catch:"+id))
    .catch(alert)
  }

  function updateBtnHandler(e){
    let dataField= e.target.parentNode;
    let id =dataField.getAttribute("data-id")
    let entity = {
      "angler":dataField.getElementsByClassName("angler")[0].value,
      "weight":dataField.getElementsByClassName("weight")[0].value,
      "species":dataField.getElementsByClassName("species")[0].value,
      "location":dataField.getElementsByClassName("location")[0].value,
      "bait":dataField.getElementsByClassName("bait")[0].value,
      "captureTime":dataField.getElementsByClassName("captureTime")[0].value
    }
    catchService.update(id,entity)
    .then(alert("Successfully updated catch:"+id))
    .catch(alert)
  }

  function loadBtnHanlder(){
    catchService.all()
    .then(res=>res.json())
    .then(result=>{
     let catchTemplate =  initElements().catchPattern();
     clearTemplate(catchTemplate);
     if(result!==null){
        let allCatches = Object.keys(result);         
                 allCatches.forEach(c=>{
           let catchClone = catchTemplate.cloneNode(true)
           catchClone.setAttribute("data-id",c)
           let [angler,weight,species,location,bait,captureTime] =  catchClone.getElementsByTagName("input")
           angler.value = result[c].angler;
           weight.value = result[c].weight;
           species.value = result[c].species;
           location.value = result[c].location;
           bait.value = result[c].bait;
           captureTime.value = result[c].captureTime;
           initElements().catchesDiv().appendChild(catchClone)
          
        })
      
 initElements().updateBtns()
 .forEach(btn=>{
btn.addEventListener("click",updateBtnHandler)
 })
 
 initElements().deleteBtns()
 .forEach(btn=>{
   btn.addEventListener("click",deleteBtnHandler)
 })
}}).catch(alert)
  }

  function clearTemplate(catchTemplate){
    if(catchTemplate ===null){
     throw new Error("The template is null!")
     }  
     return document.getElementById("catches").removeChild(catchTemplate);
  }

 initElements().loadBtn()
 .addEventListener("click",loadBtnHanlder);

  initElements().addBtn()
  .addEventListener("click",addBtnHandler)
}

attachEvents();