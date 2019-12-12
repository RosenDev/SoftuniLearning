import {Requester} from './requester.js'


export class User {
    constructor(authType,authHash) {
        this.authHash=authHash
        this.requester = new Requester("https://baas.kinvey.com")
    }

    async registerAsync(user){

return await this.requester
.sendBodyRequest("POST","/user/kid_BJgTCR0sr/",{username:user.username,password:user.password},"Basic",this.authHash)
.then(res=>res.json())
.then(result=>{ 
    localStorage
    .setItem("authtoken",result._kmd.authtoken);
    localStorage.setItem("username",result.username)
}).catch(err=>{throw err})
 
    }

    isUserLogged(){
        return  this.getToken()!==null;
    }
getUsername(){
    return localStorage.getItem("username");
}
deleteToken(){
return localStorage.removeItem("authtoken")
}
getToken(){
    return localStorage.getItem("authtoken")
}
    async logoutAsync(){
        return await this.requester
        .sendBodyRequest("POST","/user/app_id/_logout",null,this.authType,sessionStorage.getItem("authtoken"))
        .catch(err=>{throw err})

    } 

    async loginAsync(username,password)
    {
     return await this.requester
     .sendBodyRequest("POST","/user/kid_BJgTCR0sr/login",{username,password},"Basic",this.authHash)
     .then(res=>res.json())
     .then(result=>{localStorage
        .setItem("authtoken",result._kmd.authtoken);
      localStorage.setItem("username",username)})
      .catch(err=>{throw err});
    }


}