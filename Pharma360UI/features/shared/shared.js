$(window).on("load", function () {
  fetch("/features/language-switcher/language-switcher.html")
    .then((res) => res.text())
    .then((html) => {
      document.getElementById("language-switcher-container").innerHTML = html;
      const script = document.createElement("script");
      script.src = "/features/language-switcher/language-switcher.js";
      document.body.appendChild(script);
    });

  const loadComponent = async (containerId, url) => {
    const res = await fetch(url);
    const html = await res.text();
    document.getElementById(containerId).innerHTML = html;
  };

  loadComponent("footer-container", "/features/shared/footer.html"); // Load de Script for the footer with fetch
  loadComponent("header-container", "/features/shared/header.html"); // Load de Script for the footer with fetch
  loadComponent("hero-container", "/features/home/hero.html"); // Load de Script for the footer with fetch
  
  //Load the language switcher component
  if (typeof savedLang === "undefined") {
    var savedLang = localStorage.getItem("lang") || "es";
  } else {
    savedLang = localStorage.getItem("lang") || "es";
  }

  loadLanguage(savedLang);

  fetch('/features/shared/footer.html')
    .then((res) => res.text())
    .then((html) => {
      document.getElementById("footer-container").innerHTML = html;
      const script = document.createElement("script");
      script.src = "/features/shared/footer.js";
      document.body.appendChild(script);
      loadLanguage(savedLang);
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
