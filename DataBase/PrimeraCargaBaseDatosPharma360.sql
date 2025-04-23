USE Pharma360;
GO

-- Categorías
INSERT INTO Categoria (Nombre) VALUES
('Analgésicos'),
('Antibióticos'),
('Vitaminas');

-- Productos
INSERT INTO Producto (Nombre, Precio, Stock, IdCategoria) VALUES
('Paracetamol 500mg', 5.50, 100, 1),
('Ibuprofeno 200mg', 6.75, 120, 1),
('Amoxicilina 500mg', 12.00, 50, 2),
('Vitamina C 1000mg', 8.00, 80, 3);

-- Clientes
INSERT INTO Cliente (Nombre, Direccion, Telefono, Correo) VALUES
('Carlos Pérez', 'Av. Central 123', '987654321', 'carlos@mail.com'),
('Laura Gómez', 'Calle Falsa 456', '912345678', 'laura@mail.com');

-- Proveedores
INSERT INTO Proveedor (Nombre, Telefono, Direccion) VALUES
('FarmaDistribuciones S.A.', '999888777', 'Parque Industrial Norte'),
('SaludGlobal Ltda.', '988877766', 'Zona Industrial Sur');

-- Compras
INSERT INTO Compra (Fecha, Total, IdProveedor) VALUES
(GETDATE(), 600.00, 1),
(GETDATE(), 300.00, 2);

-- Detalle de Compras
INSERT INTO DetalleCompra (IdCompra, IdProducto, Cantidad, PrecioUnitario) VALUES
(1, 1, 100, 5.00),
(1, 3, 50, 11.50),
(2, 2, 60, 6.25),
(2, 4, 40, 7.50);

-- Ventas
INSERT INTO Venta (Fecha, Total, IdCliente) VALUES
(GETDATE(), 30.00, 1),
(GETDATE(), 45.00, 2);

-- Detalle de Ventas
INSERT INTO DetalleVenta (IdVenta, IdProducto, Cantidad, PrecioUnitario) VALUES
(1, 1, 3, 5.50),
(1, 4, 1, 8.00),
(2, 2, 4, 6.75),
(2, 3, 1, 12.00);
