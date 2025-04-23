-- Crear la base de datos
CREATE DATABASE FleetAuthDB;
GO

USE FleetAuthDB;
GO

-- Tabla de Usuarios
CREATE TABLE Users (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Username NVARCHAR(100) NOT NULL UNIQUE,
    Email NVARCHAR(255) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(MAX) NOT NULL,
    UserType NVARCHAR(50) NOT NULL, -- Admin, Pasajero, Conductor, etc.
    IsActive BIT DEFAULT 1,
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

CREATE TABLE Permissions (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(100) NOT NULL UNIQUE,  -- Ej: 'perm.read', 'perm.delete'
    Description NVARCHAR(255)
);
GO

-- Tabla de Roles
CREATE TABLE Roles (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    Name NVARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE RolePermissions (
    RoleId UNIQUEIDENTIFIER NOT NULL,
    PermissionId UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY (RoleId, PermissionId),
    FOREIGN KEY (RoleId) REFERENCES Roles(Id),
    FOREIGN KEY (PermissionId) REFERENCES Permissions(Id)
);
GO

-- Relación Usuario - Rol (muchos a muchos)
CREATE TABLE UserRoles (
    UserId UNIQUEIDENTIFIER NOT NULL,
    RoleId UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY(UserId, RoleId),
    FOREIGN KEY (UserId) REFERENCES Users(Id),
    FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);
GO

-- Tokens de refresco para sesión persistente (opcional)
CREATE TABLE RefreshTokens (
    Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    UserId UNIQUEIDENTIFIER NOT NULL,
    Token NVARCHAR(MAX) NOT NULL,
    ExpiresAt DATETIME NOT NULL,
    IsRevoked BIT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);
GO

-- Índices útiles
CREATE INDEX IX_Users_Email ON Users (Email);
CREATE INDEX IX_RefreshTokens_UserId ON RefreshTokens (UserId);
GO

-- Insertar roles por defecto
INSERT INTO Roles (Id, Name) VALUES
(NEWID(), 'Admin'),
(NEWID(), 'Operador'),
(NEWID(), 'Conductor'),
(NEWID(), 'Pasajero');
GO
