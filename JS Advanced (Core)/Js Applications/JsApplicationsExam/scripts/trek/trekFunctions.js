import {Requester} from "../requester.js"
import {User} from "../user.js"
const requester= new Requester("https://baas.kinvey.com")

const user = new User(undefined,undefined)
function getAllTreks()
{   return requester.sendNonBodyRequest("GET","/appdata/kid_BJgTCR0sr/treks","Kinvey",user.getToken())
    .then(res=>res.json())
}


export { getAllTreks}