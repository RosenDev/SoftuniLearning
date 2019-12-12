export class Requester{

    constructor(baseUrl){
      this.appKey=""
      this.appSecret=""
     this.headers = {
         "Content-Type":"application/json",
         "X-Kinvey-API-Version": 3
        }

     this.baseUrl = baseUrl;
    }
  
     handleError(e){
      if(!e.ok){
        throw new Error(e.statusText);
      }
      return e;
    }

  async sendBodyRequest(method,subUrl,body,authType,authHash){

    this.headers["Authorization"]= `${authType} ${authHash}`

       return await fetch(this.baseUrl+subUrl,{
         method:method,
         headers:this.headers,
         body:body===null?null:JSON.stringify(body)
     })
     .then(this.handleError);
  }


  async sendNonBodyRequest(method,subUrl,authType,authHash){

    if(authType==="Kinvey"){
      this.headers["Authorization"]= `${authType} ${authHash}`
    }else{
      this.headers["Authorization"]= `${authType} ${authHash}`
    }
    
    return await fetch(this.baseUrl+subUrl,{
      method:method,
      headers:this.headers
    })
    .then(this.handleError)
  }
}

