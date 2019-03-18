// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


// Open panel for a new book
//
newButton.addEventListener("click", function () {
    editPanel.style.visibility = "visible";    
});

// Create new book on server
//
saveButton.addEventListener("click", function (e) {
    var form = new FormData();
    form.append("title", title.value);
    form.append("authors", authors.value);

    fetch("api/books", {
        method: "POST",
        body: form
    }).then(function (response) {
        // add to book list
        let table = document.getElementsByTagName("tbody")[0];
        let newRow = document.createElement("tr");
        newRow.innerHTML = `
            <td width="100">${title.value}</td>
            <td width="100">${authors.value}</td >
            <td width="40"> Edit | Del </td>`;
        table.appendChild(newRow);

    }).catch(alert);


    editPanel.style.visibility = "hidden";  
});

// Open panel to edit book
//
newButton.addEventListener("click", function () {
    editPanel.style.visibility = "visible";
});

