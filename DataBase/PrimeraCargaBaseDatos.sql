USE FleetAuthDB;
GO

-- Obtener los IDs de los roles para reutilizar
DECLARE @AdminRoleId UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM Roles WHERE Name = 'Admin');
DECLARE @OperadorRoleId UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM Roles WHERE Name = 'Operador');
DECLARE @ConductorRoleId UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM Roles WHERE Name = 'Conductor');
DECLARE @PasajeroRoleId UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM Roles WHERE Name = 'Pasajero');

-- Insertar usuarios de prueba
DECLARE @AdminId UNIQUEIDENTIFIER = NEWID();
DECLARE @OperadorId UNIQUEIDENTIFIER = NEWID();
DECLARE @Cliente2 UNIQUEIDENTIFIER = NEWID();
DECLARE @Cliente1 UNIQUEIDENTIFIER = NEWID();

INSERT INTO Users (Id, Username, Email, PasswordHash, UserType)
VALUES
(@AdminId, 'admin1', 'admin1@pharma360.com', 'hashed_admin_pw', 'Admin'),
(@OperadorId, 'operador1', 'operador1@pharma360.com', 'hashed_operador_pw', 'Operador'),
(@Cliente2, 'cliente2', 'cliente2@pharma360.com', 'hashed_conductor_pw', 'Cliente'),
(@Cliente1, 'cliente1', 'cliente1@pharma360.com', 'hashed_pasajero_pw', 'Cliente');

-- Asignar roles
INSERT INTO UserRoles (UserId, RoleId)
VALUES
(@AdminId, @AdminRoleId),
(@OperadorId, @OperadorRoleId),
(@Cliente2, @ConductorRoleId),
(@Cliente1, @PasajeroRoleId);

-- Insertar tokens de refresco (opcional)
INSERT INTO RefreshTokens (UserId, Token, ExpiresAt)
VALUES
(@AdminId, 'admin_refresh_token_123', DATEADD(DAY, 7, GETDATE())),
(@OperadorId, 'operador_refresh_token_456', DATEADD(DAY, 7, GETDATE())),
(@Cliente2, 'conductor_refresh_token_789', DATEADD(DAY, 7, GETDATE())),
(@Cliente1, 'pasajero_refresh_token_101', DATEADD(DAY, 7, GETDATE()));
GO

USE FleetAuthDB;

-- 1. Insertar permisos base (si no existen)
IF NOT EXISTS (SELECT * FROM Permissions WHERE Name = 'perm.read')
BEGIN
    INSERT INTO Permissions (Name, Description) VALUES
    ('perm.product.read', 'Permiso para consultar datos'),
    ('perm.product.create', 'Permiso para crear registros'),
    ('perm.product.update', 'Permiso para modificar registros'),
    ('perm.product.delete', 'Permiso para eliminar registros');
END

-- 2. Obtener IDs de roles
DECLARE @AdminId UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM Roles WHERE Name = 'Admin');
DECLARE @OperadorId UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM Roles WHERE Name = 'Operador');
DECLARE @Cliente UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM Roles WHERE Name = 'Cliente');
DECLARE @Supervisor UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM Roles WHERE Name = 'Supervisor');

-- 3. Obtener IDs de permisos
DECLARE @ReadPerm UNIQUEIDENTIFIER = (SELECT Id FROM Permissions WHERE Name = 'perm.product.read');
DECLARE @CreatePerm UNIQUEIDENTIFIER = (SELECT Id FROM Permissions WHERE Name = 'perm.product.create');
DECLARE @UpdatePerm UNIQUEIDENTIFIER = (SELECT Id FROM Permissions WHERE Name = 'perm.product.update');
DECLARE @DeletePerm UNIQUEIDENTIFIER = (SELECT Id FROM Permissions WHERE Name = 'perm.product.delete');

-- 4. Asignar permisos al rol Admin (todos)
INSERT INTO RolePermissions (RoleId, PermissionId)
SELECT @AdminId, Id FROM Permissions
WHERE Id NOT IN (SELECT PermissionId FROM RolePermissions WHERE RoleId = @AdminId);

-- 5. Asignar solo 'read' a Cliente y al Operador
IF NOT EXISTS (SELECT 1 FROM RolePermissions WHERE RoleId = @Cliente AND PermissionId = @ReadPerm)
    INSERT INTO RolePermissions (RoleId, PermissionId) VALUES (@Cliente, @ReadPerm);

IF NOT EXISTS (SELECT 1 FROM RolePermissions WHERE RoleId = @OperadorId AND PermissionId = @ReadPerm)
    INSERT INTO RolePermissions (RoleId, PermissionId) VALUES (@OperadorId, @ReadPerm);

-- 6. Asignar 'read' y 'update' al Supervisor
IF NOT EXISTS (SELECT 1 FROM RolePermissions WHERE RoleId = @Supervisor AND PermissionId = @ReadPerm)
    INSERT INTO RolePermissions (RoleId, PermissionId) VALUES (@Supervisor, @ReadPerm);

IF NOT EXISTS (SELECT 1 FROM RolePermissions WHERE RoleId = @Supervisor AND PermissionId = @UpdatePerm)
    INSERT INTO RolePermissions (RoleId, PermissionId) VALUES (@Supervisor, @UpdatePerm);