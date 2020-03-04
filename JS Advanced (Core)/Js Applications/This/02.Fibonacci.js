function getFibonator(){
  let num1 = 1;
  let num2=1;
  let temp =0;

  return function(){
 let currentNum = num1;
    temp = num2;
    num2 = num1+num2;
    if(num1 ===1){
      
    num1 = temp;
      return 1;
    }
    num1=temp;
    return currentNum;
  }
}