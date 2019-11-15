export function initElements(){
    return {
        loadBtn:()=>document.getElementById("load"),
        addBtn:()=>document.getElementById("add"),
        deleteBtns:()=>Array.from(document.getElementsByClassName("delete")),
        updateBtns:()=>Array.from(document.getElementsByClassName("update")),
        catchesDiv:()=>document.getElementById("catches"),
        catchPattern:()=> document.getElementsByClassName("catch")[0],
        addForm:()=> document.getElementById("addForm")
    }
}
