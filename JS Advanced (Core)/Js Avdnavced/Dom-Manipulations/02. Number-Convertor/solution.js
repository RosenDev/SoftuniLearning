function solve() {

const convertOptions = {
    hexadecimal:function (num){
return parseInt(num, 10).toString(16)
    },
    binary:function(num)
    {
return parseInt(num,10).toString(2);
    }
}
const select = document.getElementById("selectMenuTo");

const opitonNames = Object.keys(convertOptions);

const inputField = document.getElementById("input");

const resultField = document.getElementById("result");

const convertButton = document.getElementsByTagName("button")[0];

if(convertButton===null||select===null||resultField===null)
{
    throw new Error("Error while loading DOM. Check your tags, classes or ids");
    
}

for (const option of opitonNames) {
    const optionTag =  document.createElement("option")
    optionTag.value=option;
    optionTag.innerHTML= option.replace(option[0],option[0].toUpperCase());
    select.appendChild(optionTag);
}

convertButton.addEventListener("click", ()=>
{

    if(typeof convertOptions[select.value] ==='function')
    {
        resultField.value = convertOptions[select.value](inputField.value).toUpperCase();
    } 

   
});
}
