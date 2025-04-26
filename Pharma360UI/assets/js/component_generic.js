document.addEventListener("DOMContentLoaded", () => {
  fetch("/features/language-switcher/language-switcher.html")
    .then((res) => res.text())
    .then((html) => {
      document.getElementById("language-switcher-container").innerHTML = html;
      const script = document.createElement("script");
      script.src = "/features/language-switcher/language-switcher.js"; // Ruta completa
      document.body.appendChild(script);
    });
});
