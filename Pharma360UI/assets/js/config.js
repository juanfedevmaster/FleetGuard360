let endpoints = null;
let currentEnv = "dev"; // Puedes cambiar a "prod" según el entorno

async function loadConfig() {
  if (!endpoints) {
    const res = await fetch("/assets/config/endpoints.json");
    const data = await res.json();
    endpoints = data;
  }
}

async function getEndpoint(path) {
  await loadConfig();

  const keys = path.split(".");
  let value = endpoints[currentEnv];

  for (const key of keys) {
    value = value?.[key];
    if (!value) throw new Error(`Endpoint "${path}" not found`);
  }

  return value;
}
