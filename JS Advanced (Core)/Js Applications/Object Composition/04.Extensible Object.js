function result (){
const obj ={
extend(template){
for(let key in template){
    if(typeof template[key]==='function'){
        Object.getPrototypeOf(obj)[key]=template[key]
    }else{
    obj[key]= template[key]
    }
}
}
}
return obj;
};