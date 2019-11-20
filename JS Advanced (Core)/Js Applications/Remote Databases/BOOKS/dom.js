export function domElements(){
    return {
        resultsOutput:()=> document.getElementById("resultsOutput"),
        submitBtn:()=> document.getElementById("submitBtn"),
        titleField:()=> document.getElementById("title"),
        authorField:()=> document.getElementById("author"),
        isbnField:()=> document.getElementById("isbn"),
        loadBooksBtn:()=> document.getElementById("loadBooks")
    }
}