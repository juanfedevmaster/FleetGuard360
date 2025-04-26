if(typeof savedLang === "undefined") {
  var savedLang = localStorage.getItem("lang") || "es";
}else {
  savedLang = localStorage.getItem("lang") || "es";
}

updateLanguageButton(savedLang);

function changeLanguage(lang) {
  localStorage.setItem("lang", lang);
  loadLanguage(lang);
  updateLanguageButton(lang);
}

function updateLanguageButton(lang) {
  const flagSpan = document.getElementById("selected-language-flag");
  const labelSpan = document.getElementById("selected-language-label");

  if (lang === "es") {
    flagSpan.innerHTML = `<img src="/assets/images/flags/es.svg" width="16" />`;
    labelSpan.textContent = "Español";
  } else if (lang === "en") {
    flagSpan.innerHTML = `<img src="/assets/images/flags/us.svg" width="16" />`;
    labelSpan.textContent = "English";
  }
}
