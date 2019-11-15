export class CatchService{

  constructor(){
    
  }
  async all(){
    let data =  await fetch("https://fisher-game.firebaseio.com/catches.json");
   return data;
   }
   
   async add(entity){
   return await fetch("https://fisher-game.firebaseio.com/catches.json",{
       method:"POST",
       headers: {
           'Accept': 'application/json',
           'Content-Type': 'application/json'
         },
         body:JSON.stringify(entity), 
   })
   }
   
   async update(id,newEntity){
     return await fetch(`https://fisher-game.firebaseio.com/catches/${id}.json`,{
       method:"PUT",
       headers: {
           'Accept': 'application/json',
           'Content-Type': 'application/json'
         },
         body:JSON.stringify(newEntity), 
   })
   }
   async remove(id){
     return await fetch(`https://fisher-game.firebaseio.com/catches/${id}.json`,{
       method:"DELETE"
   })
   }
}
