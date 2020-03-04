class Company {

    constructor(){
        this.departments=[]
    }

    addEmployee(username,salary,position,department){
      if(this._isUndefinedNullOrEmpty(username)||
      this._isUndefinedNullOrEmpty(salary)||
      this._isUndefinedNullOrEmpty(position)||
      this._isUndefinedNullOrEmpty(department)||salary<0){
       throw new Error("Invalid input!");
      }
      if(this.departments.length===0||!this.departments.some(x=>x['name']===department)){
        this.departments.push({name:department,employees:[]});
      }
       this.departments.find(x=>x.name===department).employees.push({username:username,position:position,salary:Number(salary.toFixed(2))});

      return `New employee is hired. Name: ${username}. Position: ${position}`;
      
    }


  bestDepartment(){

    let dpSort= (dep1,dep2)=> Number(dep2.employees
    .map(x=>x.salary)
    .reduce((a,b)=>a+b,0).toFixed(2))/dep2.employees.length-(Number(dep1.employees
    .map(x=>x.salary)
    .reduce((a,b)=>a+b,0).toFixed(2))/dep1.employees.length);

    let salarySort = (empl1,empl2) => empl2.salary-empl1.salary;
    let usernameSort =(empl1,empl2) => empl1.username.localeCompare(empl2.username);
let allSort= function (emp1,emp2){
         return salarySort(emp1,emp2)||usernameSort(emp1,emp2);
}
    let bestDp = this.departments.sort(dpSort)[0]
 let sortedEmployees =  bestDp.employees
 .sort(allSort)
 
    let msg=`Best Department is: ${bestDp.name}\n`+
        `Average salary: ${Number((Number(bestDp.employees.map(x=>x.salary)
        .reduce((a,b)=>a+b,0).toFixed(2))/bestDp.employees.length).toFixed(2)).toFixed(2)}\n`+
       sortedEmployees
      .map(e=>`${e.username} ${e.salary} ${e.position}`)
        .join("\n");
        return msg;
  }

    _isUndefinedNullOrEmpty(string){
  return string===undefined||string===null||string==='';
    }
}
