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

## 🛠 Setup

```bash
cd Pharma360WebApi
dotnet ef database update
dotnet run
```

Acceso a Swagger: https://localhost:{port}/swagger

## 📁 Estructura

- `appsettings.json`: configuración de rutas
- `Program.cs`: setup del gateway

# 📃 Licencia
Este proyecto es parte del sistema Pharma360, desarrollado con fines educativos y académicos. Puedes adaptarlo para otros sistemas con fines propios o comerciales.

# ✉️ Contacto
Desarrollado por Juan Felipe Quintana Gómez

📧 juanfedevmaster@gmail.com

🔗 https://www.linkedin.com/in/juan-felipe-quintana-g%C3%B3mez-94b86337/
