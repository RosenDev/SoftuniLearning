function solve() {

const info = document.getElementById("info");
const departBtn =  document.getElementById("depart");
const arriveBtn =  document.getElementById("arrive");
let previousId ="";
let currentName ="depot";
let currentId = "depot";

function disableButton(btn){
  return  btn.setAttribute("disabled","true");
}

function enableButton(btn){
  return btn.removeAttribute("disabled");
}

function outputResult(result,output){
  return output.textContent = result;
}
    function depart() {
        fetch(`https://judgetests.firebaseio.com/schedule/${currentId}.json `)
        .then(data=>data.json())
        .then(result=>{
            disableButton(departBtn);
            enableButton(arriveBtn);
            outputResult(`Next stop ${result.name}`,info.getElementsByTagName("span")[0]);
            currentId = result.next
            currentName = result.name;
        })
        .catch(err=>{
            outputResult("Error",info.getElementsByTagName("span")[0]);
            disableButton(departBtn);
            disableButton(arriveBtn);
         })
    }

    function arrive() {
       outputResult(`Arriving at ${currentName}`,info.getElementsByTagName("span")[0]);
       disableButton(arriveBtn);
       enableButton(departBtn);
    }

    return {
        depart,
        arrive
    };
}

let result = solve();