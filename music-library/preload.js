const { ipcRenderer } = require("electron");

console.log("Preload script loaded successfully");

document.addEventListener("DOMContentLoaded", () => {
  const prefixButton = document.getElementById("prefix");
  const queryButton = document.getElementById("query");

  prefixButton.addEventListener("click", () => {
    loadPage("prefix.html");
  });

  queryButton.addEventListener("click", () => {
    loadPage("query.html");
  });

  function loadPage(page) {
    ipcRenderer.send("change-file", page);
  }
});
