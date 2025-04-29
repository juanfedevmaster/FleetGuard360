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

function getClaimsJwt(token) {
  try {
    const base64Url = token.split(".")[1];
    const base64 = decodeURIComponent(
      atob(base64Url)
        .split("")
        .map((c) => "%" + c.charCodeAt(0).toString(16).padStart(2, "0"))
        .join("")
    );
    return JSON.parse(base64);
  } catch (e) {
    console.error("Token inválido", e);
    return null;
  }
}