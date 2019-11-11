function attachEvents() {
  const mainDiv = document.getElementById("content");

  const messagesField = document.getElementById("messages");
  const authorField = document.getElementById("author");
  const contentField = document.getElementById("content");

  const submitBtn = document.getElementById("submit");
  submitBtn.addEventListener("click", addMessage);
  const refreshBtn = document.getElementById("refresh");
  refreshBtn.addEventListener("click", refreshMessages);

  function addMessage(){
      const author = authorField.value;
      const content = contentField.value;

      const headers = {
          method: "POST",
          headers: {
              "Content-Type": "application/json"
          },
          body: JSON.stringify({
              author,
              content
          })
      }

      fetch(`https://rest-messanger.firebaseio.com/messanger.json`, headers)
          .then(() => {
              clearOutput();
              authorField.value = "";
              contentField.value = "";

              refreshMessages();
          })
      .catch(outputError);
  }

  function refreshMessages(){
      clearOutput();
      fetch(`https://rest-messanger.firebaseio.com/messanger.json`)
          .then((res) => res.json())
          .then(data => {
              Object.entries(data)
                  .forEach(([elId, messageData]) => {
                      const {author, content} = messageData;

                      const li = document.createElement("li");
                      li.textContent = `${author}: ${content}`;
                      messagesField.append(li.textContent + "\n")
                  })
          })
          .catch(outputError); 
  }

  function clearOutput(){
      messagesField.innerText = "";
  }

  function outputError(){
      messagesField.innerText = "An error occurred";
  }

  return {
      submitMessage: addMessage,
      refreshMessage: refreshMessages
  }
}
 
  attachEvents()