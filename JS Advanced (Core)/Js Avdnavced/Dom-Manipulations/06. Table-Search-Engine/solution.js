function solve() {
 const searchInput = document.getElementById("searchField");
 const searchBtn = document.getElementById("searchBtn");
 let rowsArr = [];
 const tableBody = document.getElementsByTagName("tbody")[0];
 const rows = Array.from(tableBody.getElementsByTagName("tr"));

function clearClassesIfExists(row)
{
  if(row.hasAttribute("class"))
  {
   row.removeAttribute("class");
  }
}
 searchBtn.addEventListener("click",function (e) {
   
  let keyword = searchInput.value;

   searchInput.value='';
  rowsArr=[];
   rows.forEach(row=>{
     clearClassesIfExists(row);
   })
    
   rows.forEach(row => {

     let cols = row.getElementsByTagName("td");

     cols= Array.from(cols).filter(c=>c.innerHTML.includes(keyword));

     if(cols.length!==0)
     {
       rowsArr.push(row);
     }

  });
rowsArr.forEach(r=>{
  r.setAttribute("class","select")
})
 })

}