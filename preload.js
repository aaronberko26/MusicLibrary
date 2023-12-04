const { ipcRenderer } = require("electron");

console.log("Preload script loaded successfully");

document.addEventListener("DOMContentLoaded", () => {
  const songButton = document.getElementById("songs");
  const albumButton = document.getElementById("albums");
  const artistButton = document.getElementById("artists");

  songButton.addEventListener("click", () => {
    loadPage("songs.html");
  })

  albumButton.addEventListener("click", () => {
    loadPage("albums.html");
  })

  artistButton.addEventListener("click", () => {
    loadPage("artists.html");
  })

  function loadPage(page) {
    ipcRenderer.send("change-file", page);
  }
});
