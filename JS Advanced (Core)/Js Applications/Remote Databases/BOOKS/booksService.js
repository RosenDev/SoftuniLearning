export class BooksService{
    _booksTag = "/books"
    constructor(baseUrl){
      this._baseUrl = baseUrl+this._booksTag
    }

    async create(entity){
    
        return fetch(this._baseUrl,{
            method:"POST",
            headers:{
                "Content-Type":"application/json",
                "Authorization": "Basic a2lkX0JKZ1RDUjBzcjpmMzI0MzhmZGViNjI0MTJhOWIxZjhkYTMyMDFkMTU0OQ==",
                "X-Kinvey-API-Version": 3
            },

            body:JSON.stringify(entity)
        

        })
    }

    async all(){
        return await fetch(this._baseUrl,{
            method:"GET",
            headers:{
                "Content-Type":"application/json",
                "Authorization": "Basic a2lkX0JKZ1RDUjBzcjpmMzI0MzhmZGViNjI0MTJhOWIxZjhkYTMyMDFkMTU0OQ==",
                "X-Kinvey-API-Version": 3
            }
        });
    }

    async update(id,entity){
        return fetch(this._baseUrl+`/${id}`,{
            method:"PUT",
            headers:{
                "Content-Type":"application/json",
                "Authorization": "Basic a2lkX0JKZ1RDUjBzcjpmMzI0MzhmZGViNjI0MTJhOWIxZjhkYTMyMDFkMTU0OQ==",
                "X-Kinvey-API-Version": 3
            },

            body:JSON.stringify(entity)
        
        })
    }

    async delete(id){
        return fetch(this._baseUrl+`/${id}`,{
            method:"DELETE",
            headers:{
                "Content-Type":"application/json",
                "Authorization": "Basic a2lkX0JKZ1RDUjBzcjpmMzI0MzhmZGViNjI0MTJhOWIxZjhkYTMyMDFkMTU0OQ==",
                "X-Kinvey-API-Version": 3
            }
        })
    }

}