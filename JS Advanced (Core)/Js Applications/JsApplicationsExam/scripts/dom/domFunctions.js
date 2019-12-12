function clearInputFields(fields)
{
    for (const field of fields) {
        field.value ='';
    }
}


function setNotificationMessage(notifyField,msg){
    notifyField.textContent = msg;
}

function showNotification (notification)
{
notification.style.display="block"
}

export{clearInputFields,setNotificationMessage,showNotification}