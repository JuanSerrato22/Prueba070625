using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Entity.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Obtener la carpeta base (normalmente bin\Debug\netX.Y)
            var basePath = AppContext.BaseDirectory;

            // Subimos cuatro niveles para llegar a la raíz de la solución (ajusta si es necesario)
            var solutionRoot = Path.GetFullPath(Path.Combine(basePath, "..", "..", "..", ".."));

            // Construimos la ruta hacia la carpeta Web donde está el appsettings.json
            var webProjectPath = Path.Combine(solutionRoot, "Web");

            Console.WriteLine($"Ruta para appsettings.json: {webProjectPath}");

            // Configuramos el ConfigurationBuilder para cargar el appsettings.json del proyecto Web
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(webProjectPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Obtenemos la cadena de conexión
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Configuramos DbContextOptions con MySQL y la cadena de conexión
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            // Retornamos la instancia del contexto, pasándole las opciones y la configuración
            return new ApplicationDbContext(optionsBuilder.Options, configuration);
        }
    }
}
