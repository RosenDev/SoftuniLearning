function getInfo() {
  const stopId =  document.getElementById("stopId").value;
  const stopNameField = document.getElementById("stopName");
  const busesUl =  document.getElementById("buses");

  function displayResult(stopName,buses, stNameOutput,busesOutput){
   stNameOutput.textContent = stopName;
   Object.entries(buses)
   .map(b=>{
     let li=document.createElement("li")
     li.textContent=`Bus ${b[0]} arrives in ${b[1]}`;
     return li;
    })
    .forEach(bus=> {
      busesOutput.appendChild(bus);
    });
  }

  fetch(`https://judgetests.firebaseio.com/businfo/${stopId}.json`)
.then(response=>response.json())
.then(data=>displayResult(data.name,data.buses,stopNameField,busesUl))
.catch(console.log)


}