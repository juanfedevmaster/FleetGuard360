# FleetGuard360

# 🔐 AuthService - Microservicio de Autenticación para FleetGuard360

AuthService es un microservicio desarrollado en **.NET 8** que forma parte de la arquitectura distribuida del sistema **FleetGuard360**. Su función principal es gestionar la autenticación de usuarios mediante **JWT (JSON Web Tokens)**, con soporte para múltiples roles como **Administrador, Operador, Conductor y Pasajero**.

---

## 🚀 Características

- Registro de usuarios con hash seguro de contraseñas (BCrypt)
- Inicio de sesión con validación y emisión de JWT
- Soporte para Refresh Tokens (opcional)
- Autenticación centralizada para microservicios
- Integración sencilla con API Gateway (YARP, Azure API Mgmt, etc.)
- Roles y claims personalizados incluidos en el token

---

## 📦 Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local o en la nube)
- Visual Studio 2022+ o VS Code
- [Postman](https://www.postman.com/) o Swagger para pruebas

---

## ⚙️ Instalación

1. Clona este repositorio:
   ```bash
   git clone https://github.com/tu_usuario/AuthService.git
   cd AuthService
2. Configura la cadena de conexión en appsettings.json:

   ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Database=FleetAuthDB;Trusted_Connection=True;"
    }
    ```
3. Aplica las migraciones (si usas EF Core):
   ```bash
   dotnet ef database update
4. Ejecuta la API:
   ```bash
   dotnet run
5. Accede a la documentación Swagger en:
   ```bash
   https://localhost:5001/swagger
---
# 🔑 Endpoints disponibles

| Método | Ruta | Descripción |
|-----------|-----------|-----------|
| POST    | /api/auth/register    | Registro de nuevo usuario    |
| POST    | /api/auth/login    | Login y generación de token JWT    |

---
# 🔐 JWT

El servicio emite tokens JWT que incluyen:

```bash sub```: ID del usuario

```bash name```: nombre de usuario

```bash role```: rol (Admin, Conductor, etc.)

Ejemplo de JWT payload:
 ```json
  {
  "sub": "794f4f35-3d27-43dc-9454-fb658950bb1b",
  "name": "admin1",
  "role": "Admin",
  "permission": [
    "perm.create",
    "perm.delete",
    "perm.read",
    "perm.update"
  ],
  "exp": 1745387907,
  "iss": "FleetGuard360.Auth",
  "aud": "FleetGuard360.API"
}
 ```
---
# 🧱 Estructura del Proyecto

```pgsql
AuthService/
├── Controllers/
├── Services/
├── appsettings.json
├── Program.cs
└── AuthService.csproj

ApiGateway.Data/
├── AuthDbContext.cs

ApiGateway.Models
├── DTOs/
├── Entities/
├── Helpers/
```
---
# 📃 Licencia
Este proyecto es parte del sistema FleetGuard360, desarrollado con fines educativos y académicos. Puedes adaptarlo para otros sistemas con fines propios o comerciales.

# ✉️ Contacto
Desarrollado por Juan Felipe Quintana Gómez

📧 juanfedevmaster@gmail.com

🔗 https://www.linkedin.com/in/juan-felipe-quintana-g%C3%B3mez-94b86337/
