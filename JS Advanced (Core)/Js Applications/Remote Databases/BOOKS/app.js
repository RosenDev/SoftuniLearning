import { domElements } from "./dom.js";
import {BooksService} from "./booksService.js"
function attachEvents()
{
    const booksService = new BooksService("https://baas.kinvey.com/appdata/kid_BJgTCR0sr")
    function createBookHandler(e){
        e.preventDefault();
     let book={
         "title":domElements().titleField().value,
         "author":domElements().authorField().value,
         "isbn":domElements().isbnField().value
     }

     booksService.create(book)
     .then(()=>{alert("Succesfully created new book."); 
     reloadPage();
    })
     .catch(alert);
    }

    function loadAllBooksHandler(){
    const output = domElements().resultsOutput();
    
    booksService.all()
    .then(response=>response.json())
    .then(result=>{
        result.forEach(b => {
            const tr= document.createElement("tr");
            const title = document.createElement("td");
            const author = document.createElement("td");
            const isbn =  document.createElement("td");

            title.textContent = b.title;
            author.textContent = b.author;
            isbn.textContent = b.isbn

            const actionsField = document.createElement("td");
            const editButton = document.createElement("button")
            editButton.textContent="Edit"

            const deleteButton = document.createElement("button")
            deleteButton.textContent="Delete"
            editButton.setAttribute("data-id",b._id);
            deleteButton.setAttribute("data-id",b._id);
            editButton.addEventListener("click",editClickHandler);
            deleteButton.addEventListener("click",deleteHandler);
            
            actionsField.appendChild(editButton);
            actionsField.appendChild(deleteButton);
            
            tr.appendChild(title);
            tr.appendChild(author);
            tr.appendChild(isbn);
            tr.appendChild(actionsField);
            output.appendChild(tr);

        });
    })

    }
    function saveChangesClickHandler(e){
     e.preventDefault();
     let id =e.target.getAttribute("data-id");
     let newEntity =  {
         "title":domElements().titleField().value,
         "author":domElements().authorField().value,
         "isbn":domElements().isbnField().value,

     }
    domElements().authorField().value="";
    domElements().titleField().value="";
    domElements().isbnField().value="";

     booksService.update(id,newEntity)
     .then(()=>{
         alert(`Sucessfully updated book with id: ${id}.`);
         reloadPage();
     });

    }

    function editClickHandler(e){
        let saveChangesBtn=document.getElementById("saveChanges")
        if(saveChangesBtn!==null){
            document.removeChild(saveChangesBtn);
            
        }
        domElements().authorField().value=e.target.parentNode.parentNode.getElementsByTagName("td")[1].textContent;
        
        domElements().isbnField().value=e.target.parentNode.parentNode.getElementsByTagName("td")[2].textContent;
        
        domElements().titleField().value=e.target.parentNode.parentNode.getElementsByTagName("td")[0].textContent;
        saveChangesBtn =  document.createElement("button");
        saveChangesBtn.setAttribute("id","saveChanges");
        saveChangesBtn.textContent = "Save Changes";
        saveChangesBtn.setAttribute("data-id",e.target.getAttribute("data-id"));
        saveChangesBtn.addEventListener("click",saveChangesClickHandler);
        document.getElementsByTagName("form")[0].appendChild(saveChangesBtn);
        domElements().submitBtn().setAttribute("style","display:none");



    }

    function deleteHandler(e){
     let id = e.target.getAttribute("data-id")
     booksService.delete(id)
     .then(()=>{alert(`Successfully deleted book with id: ${id}.`);
        reloadPage();
    })
     .catch(alert);
     
    }

    function reloadPage(){
        location.reload();
    }

    domElements()
    .submitBtn()
    .addEventListener("click",createBookHandler);

    window.addEventListener("load",loadAllBooksHandler);
    
    domElements()
    .loadBooksBtn()
    .addEventListener("click",function(){
        reloadPage();
    });


}


attachEvents();