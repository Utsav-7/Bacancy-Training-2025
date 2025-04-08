// todo.js
let todoList = [];
const list = document.getElementById("descriptionList");
const descriptionInput = document.getElementById("description");

function addTask() {
    let description = descriptionInput.value.trim();
    if (description !== "") {
        todoList.push(description); // Store only the description
        descriptionInput.value = "";
        renderTodoList();
    }
}

function renderTodoList() {
    list.innerHTML = ""; // Clear the existing list

    todoList.forEach((item, index) => {
        const row = list.insertRow();

        const descriptionCell = row.insertCell();
        descriptionCell.textContent = item;

        const actionCell = row.insertCell();
        const deleteButton = document.createElement("button");
        deleteButton.classList.add("button");
        deleteButton.textContent = "Delete";
        deleteButton.addEventListener("click", () => deleteTask(index));
        actionCell.appendChild(deleteButton);
    });
}

function deleteTask(index) {
    todoList.splice(index, 1);
    renderTodoList();
}

// Initial rendering of the todoList
renderTodoList();