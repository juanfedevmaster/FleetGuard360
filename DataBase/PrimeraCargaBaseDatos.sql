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
DECLARE @ConductorId UNIQUEIDENTIFIER = NEWID();
DECLARE @PasajeroId UNIQUEIDENTIFIER = NEWID();

INSERT INTO Users (Id, Username, Email, PasswordHash, UserType)
VALUES
(@AdminId, 'admin1', 'admin1@fleet.com', 'hashed_admin_pw', 'Admin'),
(@OperadorId, 'operador1', 'operador1@fleet.com', 'hashed_operador_pw', 'Operador'),
(@ConductorId, 'conductor1', 'conductor1@fleet.com', 'hashed_conductor_pw', 'Conductor'),
(@PasajeroId, 'pasajero1', 'pasajero1@fleet.com', 'hashed_pasajero_pw', 'Pasajero');

-- Asignar roles
INSERT INTO UserRoles (UserId, RoleId)
VALUES
(@AdminId, @AdminRoleId),
(@OperadorId, @OperadorRoleId),
(@ConductorId, @ConductorRoleId),
(@PasajeroId, @PasajeroRoleId);

-- Insertar tokens de refresco (opcional)
INSERT INTO RefreshTokens (UserId, Token, ExpiresAt)
VALUES
(@AdminId, 'admin_refresh_token_123', DATEADD(DAY, 7, GETDATE())),
(@OperadorId, 'operador_refresh_token_456', DATEADD(DAY, 7, GETDATE())),
(@ConductorId, 'conductor_refresh_token_789', DATEADD(DAY, 7, GETDATE())),
(@PasajeroId, 'pasajero_refresh_token_101', DATEADD(DAY, 7, GETDATE()));
GO

USE FleetAuthDB;

-- 1. Insertar permisos base (si no existen)
IF NOT EXISTS (SELECT * FROM Permissions WHERE Name = 'perm.read')
BEGIN
    INSERT INTO Permissions (Name, Description) VALUES
    ('perm.read', 'Permiso para consultar datos'),
    ('perm.create', 'Permiso para crear registros'),
    ('perm.update', 'Permiso para modificar registros'),
    ('perm.delete', 'Permiso para eliminar registros');
END

-- 2. Obtener IDs de roles
DECLARE @AdminId UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM Roles WHERE Name = 'Admin');
DECLARE @OperadorId UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM Roles WHERE Name = 'Operador');
DECLARE @ConductorId UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM Roles WHERE Name = 'Conductor');
DECLARE @PasajeroId UNIQUEIDENTIFIER = (SELECT TOP 1 Id FROM Roles WHERE Name = 'Pasajero');

-- 3. Obtener IDs de permisos
DECLARE @ReadPerm UNIQUEIDENTIFIER = (SELECT Id FROM Permissions WHERE Name = 'perm.read');
DECLARE @CreatePerm UNIQUEIDENTIFIER = (SELECT Id FROM Permissions WHERE Name = 'perm.create');
DECLARE @UpdatePerm UNIQUEIDENTIFIER = (SELECT Id FROM Permissions WHERE Name = 'perm.update');
DECLARE @DeletePerm UNIQUEIDENTIFIER = (SELECT Id FROM Permissions WHERE Name = 'perm.delete');

-- 4. Asignar permisos al rol Admin (todos)
INSERT INTO RolePermissions (RoleId, PermissionId)
SELECT @AdminId, Id FROM Permissions
WHERE Id NOT IN (SELECT PermissionId FROM RolePermissions WHERE RoleId = @AdminId);

-- 5. Asignar solo 'read' a Conductor y Pasajero
IF NOT EXISTS (SELECT 1 FROM RolePermissions WHERE RoleId = @ConductorId AND PermissionId = @ReadPerm)
    INSERT INTO RolePermissions (RoleId, PermissionId) VALUES (@ConductorId, @ReadPerm);

IF NOT EXISTS (SELECT 1 FROM RolePermissions WHERE RoleId = @PasajeroId AND PermissionId = @ReadPerm)
    INSERT INTO RolePermissions (RoleId, PermissionId) VALUES (@PasajeroId, @ReadPerm);

-- 6. Asignar 'read' y 'update' a Operador
IF NOT EXISTS (SELECT 1 FROM RolePermissions WHERE RoleId = @OperadorId AND PermissionId = @ReadPerm)
    INSERT INTO RolePermissions (RoleId, PermissionId) VALUES (@OperadorId, @ReadPerm);

IF NOT EXISTS (SELECT 1 FROM RolePermissions WHERE RoleId = @OperadorId AND PermissionId = @UpdatePerm)
    INSERT INTO RolePermissions (RoleId, PermissionId) VALUES (@OperadorId, @UpdatePerm);