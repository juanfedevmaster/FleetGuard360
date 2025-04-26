async function loadLanguage(lang) {
    const response = await fetch(`/assets/i18n/${lang}.json`);
    const translations = await response.json();
  
    document.querySelectorAll("[data-i18n]").forEach(el => {
      const key = el.getAttribute("data-i18n");
      if (translations[key]) {
        el.innerText = translations[key];
      }
    });
  
    document.querySelectorAll("[data-i18n-placeholder]").forEach(el => {
      const key = el.getAttribute("data-i18n-placeholder");
      if (translations[key]) {
        el.setAttribute("placeholder", translations[key]);
      }
    });
  
    localStorage.setItem("lang", lang); // Guardamos preferencia
  }
  
  if(typeof savedLang === "undefined") {
    var savedLang = localStorage.getItem("lang") || "es";
  }else {
    savedLang = localStorage.getItem("lang") || "es";
  }
  
  loadLanguage(savedLang);  