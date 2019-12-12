import{Requester} from"./requester.js"
import {User} from "./user.js"
import {getAllTreks} from "./trek/trekFunctions.js"
import {validateMinLength} from './validators/lengthValidator.js';
import {clearInputFields,setNotificationMessage,showNotification} from "./dom/domFunctions.js"
const partials ={
header:"../templates/common/header.hbs",
footer:"../templates/common/footer.hbs"

}
const requester =new Requester("https://baas.kinvey.com");
const userUtils =  new User("Kinvey","a2lkX0JKZ1RDUjBzcjpiZDFlNzU1NGUzOGY0YzE0YTQxOWEwMjY4N2VhOTE4Mg==")
const app = Sammy("body",function(){
this.use("Handlebars","hbs")

this.get("#/home",function(ctx){

ctx.loggedUser = userUtils.isUserLogged();
ctx.username = userUtils.getUsername();
if(userUtils.isUserLogged()){
    getAllTreks()
    .then(result=>{
    ctx.treks=result;
        this.loadPartials(partials)
        .then(function(){
            this.partial("../templates/home/home.hbs");
        })
    })
}else{
    this.loadPartials(partials)
        .then(function(){
            this.partial("../templates/home/home.hbs");
        })
}



});

this.get("#/register",function(){
    this.loadPartials(partials)
    .then(function(){
        this.partial("../templates/user/register.hbs");
    })
});

    this.get("#/login",function(){
        this.loadPartials(partials)
        .then(function(){
            this.partial("../templates/user/login.hbs");
        })
})


this.post("#/register",function(ctx){
let user = ctx.params;
if(user.password===user.rePassword
    &&validateMinLength(user.password,6)
    &&validateMinLength(user.username,3)){

userUtils.registerAsync(user)
.then(()=>{
 ctx.redirect("#/home");
}).catch(err=>{/*todo*/})
}

})

this.get("#/logout",function(ctx){
    requester.sendBodyRequest("POST","/user/kid_BJgTCR0sr/_logout",
    undefined,"Kinvey",userUtils.getToken())
    .then(function(){
        userUtils.deleteToken()
        ctx.redirect("#/home")
    })
    .catch(/*todo*/)
})

this.post("#/login",function(ctx){
    const {username,password}  = ctx.params;
    const usernameField = document.getElementById("inputUsername")
    
    const passwordField = document.getElementById("inputPassword")

    userUtils.loginAsync(username,password)
    .then(function(){
        clearInputFields([usernameField,passwordField])
        ctx.redirect("#/home")
    })
    .catch(/*todo*/)
})

this.get("#/create",function(ctx){
    ctx.loggedUser = userUtils.isUserLogged();
ctx.username = userUtils.getUsername();
    this.loadPartials(partials)
    .then(function(){
        this.partial("../templates/create/createTreckForm.hbs")
    })
})

this.post("#/create",function(ctx)
{
    let nameField =  document.getElementById("inputTrekName");
    let dateField = document.getElementById("inputTrekDate");
    let descrField = document.getElementById("inputTrekDescription")
    let imgField =  document.getElementById("inputTrekImage")
    //let successBox =  document.getElementById("successBox")
    let errorBox = document.getElementById("errorBox");
    const trek = ctx.params;

    if(validateMinLength(trek.location,6)
    &&validateMinLength(trek.description,10)){
      trek.organizer = userUtils.getUsername()
      trek.likes=0;

      requester.sendBodyRequest("POST","/appdata/kid_BJgTCR0sr/treks",trek,"Kinvey",userUtils.getToken())
      .then(res=>res.json())
      .then(()=>{
         // ctx.successMsg ="Trek created successfully.";
            clearInputFields([nameField,dateField,descrField,imgField])
          ctx.redirect("#/home");
      })
      .catch(err=>{   
          console.log(err)
    setNotificationMessage(errorBox,"Invalid input.")
      showNotification(errorBox)
    })
    }else{
        setNotificationMessage(errorBox,"Invalid input.")
        showNotification(errorBox)
    }

})


this.get("#/details/:id",function(ctx){
    let id = ctx.params.id;
    ctx.loggedUser = userUtils.isUserLogged()
ctx.username= userUtils.getUsername()
 requester.sendNonBodyRequest("GET",`/appdata/kid_BJgTCR0sr/treks/${id}`,"Kinvey",userUtils.getToken())
 .then(res=>res.json())
 .then(result=>{
    ctx.trek = result;
    ctx.id =  id;
    ctx.isOrganizer = result.organizer===userUtils.getUsername()
    this.loadPartials(partials)
    .then(function(){
        this.partial("../templates/details/treckDetails.hbs")
    })
 })
 
})


this.get("#/edit/:id",function(ctx){
let id= ctx.params.id;
ctx.loggedUser = userUtils.isUserLogged()
ctx.username= userUtils.getUsername()
requester.sendNonBodyRequest("GET",`/appdata/kid_BJgTCR0sr/treks/${id}`,"Kinvey",userUtils.getToken())
 .then(res=>res.json())
 .then(result=>{
    ctx.trek = result;
    ctx.id =  id;
    this.loadPartials(partials)
    .then(function(){
        this.partial("../templates/edit/editTreckForm.hbs")
    })
 })

})

this.post("#/edit/:id",function(ctx){
 let id = ctx.params.id;
let body = {
    location:ctx.params.location,
    dateTime:ctx.params.dateTime,
    description:ctx.params.description,
    imageURL:ctx.params.imageURL,
    likes:ctx.params.likes,
    organizer:ctx.params.organizer
}
 requester.sendBodyRequest("PUT",`/appdata/kid_BJgTCR0sr/treks/${id}`,body,"Kinvey",userUtils.getToken())
 .then(function(){
     ctx.redirect("#/home")
 })

})

this.get("#/close/:id",function(ctx){
let id = ctx.params.id;

requester.sendNonBodyRequest("DELETE",`/appdata/kid_BJgTCR0sr/treks/${id}`,"Kinvey",userUtils.getToken())
.then(function(){
ctx.redirect("#/home")
})
})

this.get("#/like/:id",function(ctx){
    let id = ctx.params.id; 
    requester.sendNonBodyRequest("GET",`/appdata/kid_BJgTCR0sr/treks/${id}`,"Kinvey",userUtils.getToken())
    .then(res=>res.json())
    .then(result=>{
        let updated = result;
        updated.likes++;
    requester.sendBodyRequest("PUT",`/appdata/kid_BJgTCR0sr/treks/${id}`,updated,"Kinvey",userUtils.getToken())
.then(function(){
ctx.redirect("#/home")
})
})
})
});



app.run("#/home");