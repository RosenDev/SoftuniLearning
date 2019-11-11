function solve() {

    const buttons =  Array.from(document.getElementsByTagName("button"));
      let expression="";
      const exprRegex =/\d? . \d?/gmi;
    const exprOutput =  document.getElementById("expressionOutput");
    
    const resultOutput = document.getElementById("resultOutput");

    function evaluateExpr(expr)
    {
        return Function(`"use strict";return ${exprRegex.test(expr)?expr:"'NaN'"}`)
    }
    
    function outputExpr(expr)
    {
      exprOutput.innerHTML=expr;
      return expr;
    }

     function clearExpr(expr)
     {
         expr="";
         outputExpr(expr);
        return expr;
     }

    function outputResult(result)
    {
        resultOutput.innerHTML=result;
        return result;
    }
    
    function clearResult(result) {
        result=""
        outputResult(result);
        return result;
    }
    buttons.forEach(b=>{

        b.addEventListener("click",(evt)=>{
            if(evt.target.value==='=')
            {
              outputResult(evaluateExpr(expression)())  
              expression="";
            }else if(evt.target.value.toLowerCase()==='clear'){
                expression=clearExpr(expression);
                result = clearResult(result);
            }else{
                if(!isNaN(evt.target.value)&&evt.target.value!='.')
                {
                    expression+=evt.target.value
                }else{
                    expression+=" "+evt.target.value+" ";
                }
              
                outputExpr(expression);
            }
            
        })
    })


}