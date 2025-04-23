
using Microsoft.EntityFrameworkCore;
using Pharma360WebApi.Data;
using Pharma360WebApi.Services.Categoria;
using Pharma360WebApi.Services.Clientes;
using Pharma360WebApi.Services.Compras;
using Pharma360WebApi.Services.Productos;
using Pharma360WebApi.Services.Proveedores;
using Pharma360WebApi.Services.Ventas;

namespace Pharma360WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Registro del DbContext con cadena de conexión
            builder.Services.AddDbContext<PharmaDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("PharmaDb")));

            builder.Services.AddScoped<ICategoriaService, CategoriaService>();
            builder.Services.AddScoped<IProductoService, ProductoService>();
            builder.Services.AddScoped<IClienteService, ClienteService>();
            builder.Services.AddScoped<IProveedorService, ProveedorService>();
            builder.Services.AddScoped<ICompraService, CompraService>();
            builder.Services.AddScoped<ICompraTransaccionalService, CompraTransaccionalService>();
            builder.Services.AddScoped<IVentaTransaccionalService, VentaTransaccionalService>();
            builder.Services.AddScoped<IVentaService, VentaService>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
