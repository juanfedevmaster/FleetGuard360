using Microsoft.EntityFrameworkCore;
using Pharma360WebApi.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharma360WebApi.Data
{
    public class PharmaDbContext : DbContext
    {
        public PharmaDbContext(DbContextOptions<PharmaDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<Venta> Ventas => Set<Venta>();
        public DbSet<DetalleVenta> DetalleVentas => Set<DetalleVenta>();
        public DbSet<Proveedor> Proveedores => Set<Proveedor>();
        public DbSet<Compra> Compras => Set<Compra>();
        public DbSet<DetalleCompra> DetalleCompras => Set<DetalleCompra>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Producto: Precio y Stock deben ser positivos
            modelBuilder.Entity<Producto>().ToTable(tb =>
            {
                tb.HasCheckConstraint("CK_Producto_Precio", "Precio >= 0 AND Stock >= 0");
            });

            // DetalleVenta: cantidad > 0, precio ≥ 0
            modelBuilder.Entity<DetalleVenta>().ToTable(tb =>
            {
                tb.HasCheckConstraint("CK_DetalleVenta_Cantidad", "Cantidad > 0");
                tb.HasCheckConstraint("CK_DetalleVenta_Precio", "PrecioUnitario >= 0");
            });

            // DetalleCompra: cantidad > 0, precio ≥ 0
            modelBuilder.Entity<DetalleCompra>().ToTable(tb =>
            {
                tb.HasCheckConstraint("CK_DetalleCompra_Cantidad", "Cantidad > 0");
                tb.HasCheckConstraint("CK_DetalleCompra_Precio", "PrecioUnitario >= 0");
            });

            // Relaciones
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.IdCategoria);

            modelBuilder.Entity<Producto>().ToTable("Producto");

            modelBuilder.Entity<Categoria>()
                .HasKey(c => c.IdCategoria);

            modelBuilder.Entity<Categoria>().ToTable("Categoria");

            modelBuilder.Entity<Venta>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Ventas)
                .HasForeignKey(v => v.IdCliente);

            modelBuilder.Entity<Venta>().ToTable("Venta");

            modelBuilder.Entity<DetalleVenta>()
                .HasOne(dv => dv.Venta)
                .WithMany(v => v.Detalles)
                .HasForeignKey(dv => dv.IdVenta);

            modelBuilder.Entity<DetalleVenta>()
                .HasOne(dv => dv.Producto)
                .WithMany(p => p.DetallesVenta)
                .HasForeignKey(dv => dv.IdProducto);

            modelBuilder.Entity<DetalleVenta>().ToTable("DetalleVenta");

            modelBuilder.Entity<Compra>()
                .HasOne(c => c.Proveedor)
                .WithMany(p => p.Compras)
                .HasForeignKey(c => c.IdProveedor);

            modelBuilder.Entity<Compra>().ToTable("Compra");

            modelBuilder.Entity<DetalleCompra>()
                .HasOne(dc => dc.Compra)
                .WithMany(c => c.Detalles)
                .HasForeignKey(dc => dc.IdCompra);

            modelBuilder.Entity<DetalleCompra>()
                .HasOne(dc => dc.Producto)
                .WithMany(p => p.DetallesCompra)
                .HasForeignKey(dc => dc.IdProducto);

            modelBuilder.Entity<DetalleCompra>().ToTable("DetalleCompra");


            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.IdCliente);

            modelBuilder.Entity<Cliente>().ToTable("Cliente");

            modelBuilder.Entity<Compra>()
                .HasKey(c => c.IdCompra);

            modelBuilder.Entity<DetalleCompra>()
                .HasKey(c => c.IdDetalle);

            modelBuilder.Entity<DetalleVenta>()
                .HasKey(c => c.IdDetalle);

            modelBuilder.Entity<Venta>()
                .HasKey(c => c.IdVenta);

            modelBuilder.Entity<Producto>()
                .HasKey(c => c.IdProducto);

            modelBuilder.Entity<Proveedor>().ToTable("Proveedor");

            modelBuilder.Entity<Proveedor>()
                .HasKey(c => c.IdProveedor);

            modelBuilder.Entity<Categoria>()
                .HasKey(c => c.IdCategoria);
        }

    }

}
