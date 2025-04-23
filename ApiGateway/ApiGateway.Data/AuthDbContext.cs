using ApiGateway.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiGateway.Data
{
    /// <summary>
    /// Contexto de base de datos para la autenticación y autorización.
    /// </summary>
    public class AuthDbContext : DbContext
    {
        /// <summary>
        /// Constructor de la clase <see cref="AuthDbContext"/>.
        /// </summary>
        /// <param name="options">Opciones de configuración para el contexto de base de datos.</param>
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        /// <summary>
        /// Tabla de usuarios.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Tabla de roles.
        /// </summary>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Tabla de relaciones entre usuarios y roles.
        /// </summary>
        public DbSet<UserRole> UserRoles { get; set; }

        /// <summary>
        /// Tabla de permisos.
        /// </summary>
        public DbSet<Permission> Permissions { get; set; }

        /// <summary>
        /// Tabla de relaciones entre roles y permisos.
        /// </summary>
        public DbSet<RolePermission> RolePermissions { get; set; }

        /// <summary>
        /// Tabla de tokens de actualización (Refresh Tokens).
        /// </summary>
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        /// <summary>
        /// Configura las relaciones y restricciones entre las entidades del modelo.
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo utilizado para configurar las entidades.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la clave compuesta para RolePermission
            modelBuilder.Entity<RolePermission>()
                .HasKey(rp => new { rp.RoleId, rp.PermissionId });

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId);

            modelBuilder.Entity<RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId);

            // Configuración de la clave compuesta para UserRole
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
        }
    }
}
