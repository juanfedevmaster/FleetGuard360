async function loginUser(email, password) {
  try {
    const url = await getEndpoint("auth.login");

    const response = await fetch(url, {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({ email, password }),
    });

    if (!response.ok) throw new Error("Login failed");

    const result = await response.json();
    const claims = getClaimsJwt(result.token);

    localStorage.setItem("token", result.token);

    return result;
  } catch (err) {
    console.error("Login error:", err.message);
    return null;
  }
}

document
  .getElementById("loginForm")
  .addEventListener("submit", async function (e) {
    e.preventDefault();

    const email = document.getElementById("email").value.trim();
    const password = document.getElementById("password").value.trim();

    const loginResult = await loginUser(email, password);
    if (loginResult) {
      // Redirige o muestra algo
      window.location.replace("/features/home/index.html");
    }
  });
