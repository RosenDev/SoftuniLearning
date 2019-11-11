function solve() {
  let messageBox =  document.getElementsByClassName("my-message")[0];
let chatMessages = document.getElementById("chat_messages");
let chatInput = document.getElementById("chat_input");
let sendBtn = document.getElementById("send");

if(messageBox===null||chatMessages===null||chatInput===null||sendBtn===null)
{
   throw new Error("Error while loading DOM!")
}

sendBtn.addEventListener("click",(ev)=>{
   var messageInstance =  messageBox.cloneNode();
   messageInstance.innerHTML= chatInput.value;
   chatInput.value= "";
   chatMessages.appendChild(messageInstance);
})
}


