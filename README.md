# Pharma360 

# 🔐 AuthService - Microservicio de Autenticación para FleetGuard360

AuthService es un microservicio desarrollado en **.NET 8** que forma parte de la arquitectura distribuida del sistema **FleetGuard360**. Su función principal es gestionar la autenticación de usuarios mediante **JWT (JSON Web Tokens)**, con soporte para múltiples roles como **Administrador, Operador, y cliente**.

## 🚀 Características

- Registro de usuarios con hash seguro de contraseñas (BCrypt)
- Inicio de sesión con validación y emisión de JWT
- Soporte para Refresh Tokens (opcional)
- Autenticación centralizada para microservicios
- Integración sencilla con API Gateway (YARP, Azure API Mgmt, etc.)
- Roles y claims personalizados incluidos en el token

## 📦 Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local o en la nube)
- Visual Studio 2022+ o VS Code
- [Postman](https://www.postman.com/) o Swagger para pruebas

---

# 💊 Pharma360WebApi

Microservicio encargado de la gestión de ventas, compras e inventario para el sistema Pharma360.

## 🚀 Tecnologías

- ASP.NET Core 8
- Entity Framework Core 8
- SQL Server
- Arquitectura en capas (Models, DTOs, Services, Controllers)
- Swagger UI

## 🧠 Funcionalidad

- Registro de ventas con detalle (transaccional)
- Registro de compras con detalle (transaccional)
- Control de stock automático
- Gestión de productos, clientes, proveedores
- Consultas con detalles anidados

# 📃 Licencia
Este proyecto es parte del sistema Pharma360, desarrollado con fines educativos y académicos. Puedes adaptarlo para otros sistemas con fines propios o comerciales.

# ✉️ Contacto
Desarrollado por Juan Felipe Quintana Gómez

📧 juanfedevmaster@gmail.com

🔗 https://www.linkedin.com/in/juan-felipe-quintana-g%C3%B3mez-94b86337/
