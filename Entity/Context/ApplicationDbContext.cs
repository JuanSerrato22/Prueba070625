using Dapper;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Emit;
using System.Security;

namespace Entity.Context
{
    /// <summary>
    /// Representa el contexto de la base de datos de la aplicación, proporcionando configuraciones,
    /// entidades y métodos de extensión para consultas personalizadas con Dapper.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        private IConfiguration _configuration;

        /// <summary>
        /// Constructor del contexto de la base de datos.
        /// </summary>
        /// <param name="options">Opciones de configuración del contexto.</param>
        /// <param name="configuration">Instancia de IConfiguration para acceder a valores de configuración.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
    : base(options)
        {
            _configuration = configuration;
        }

        // DBSETS
        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        /// <summary>
        /// Configura opciones adicionales del contexto, como el registro de datos sensibles.
        /// </summary>
        /// <param name="optionsBuilder">Constructor de opciones de configuración del contexto.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        /// <summary>
        /// Configura convenciones globales del modelo.
        /// </summary>
        /// <param name="configurationBuilder">Constructor de configuración del modelo.</param>
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }

        /// <summary>
        /// Configura las relaciones entre entidades del modelo.
        /// </summary>
        /// <param name="modelBuilder">Constructor de modelos.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Estudiante)
                .WithMany(e => e.Matriculas)
                .HasForeignKey(m => m.EstudianteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Curso)
                .WithMany(c => c.Matriculas)
                .HasForeignKey(m => m.CursoId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        /// <summary>
        /// Guarda los cambios en la base de datos con control de auditoría.
        /// </summary>
        /// <returns>Número de filas afectadas.</returns>
        public override int SaveChanges()
        {
            EnsureAudit();
            return base.SaveChanges();
        }

        /// <summary>
        /// Guarda los cambios de forma asíncrona con auditoría.
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">Aceptar todos los cambios si se realiza con éxito.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>Número de filas afectadas.</returns>
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            EnsureAudit();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        /// <summary>
        /// Ejecuta una consulta SQL usando Dapper y devuelve una colección de resultados del tipo especificado.
        /// </summary>
        /// <typeparam name="T">Tipo de datos del resultado.</typeparam>
        /// <param name="text">Consulta SQL.</param>
        /// <param name="parameters">Parámetros opcionales.</param>
        /// <param name="timeout">Tiempo de espera.</param>
        /// <param name="type">Tipo de comando.</param>
        /// <returns>Lista de resultados.</returns>
        public async Task<IEnumerable<T>> QueryAsync<T>(string text, object? parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryAsync<T>(command.Definition);
        }

        /// <summary>
        /// Ejecuta una consulta SQL con Dapper y devuelve el primer resultado o un valor por defecto.
        /// </summary>
        /// <typeparam name="T">Tipo de datos del resultado.</typeparam>
        /// <param name="text">Consulta SQL.</param>
        /// <param name="parameters">Parámetros de la consulta.</param>
        /// <param name="timeout">Tiempo de espera.</param>
        /// <param name="type">Tipo de comando.</param>
        /// <returns>Primer resultado encontrado o valor por defecto.</returns>
        public async Task<T> QueryFirstOrDefaultAsync<T>(string text, object parameters = null, int? timeout = null, CommandType? type = null)
        {
            using var command = new DapperEFCoreCommand(this, text, parameters, timeout, type, CancellationToken.None);
            var connection = this.Database.GetDbConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(command.Definition);
        }

        /// <summary>
        /// Método auxiliar para ejecutar lógica de auditoría.
        /// </summary>
        private void EnsureAudit()
        {
            ChangeTracker.DetectChanges();
        }

        /// <summary>
        /// Representa un comando de ejecución SQL para usar con Dapper en EF Core.
        /// </summary>
        public readonly struct DapperEFCoreCommand : IDisposable
        {
            /// <summary>
            /// Inicializa un nuevo comando SQL con Dapper.
            /// </summary>
            /// <param name="context">Contexto actual.</param>
            /// <param name="text">Texto del comando SQL.</param>
            /// <param name="parameters">Parámetros de la consulta.</param>
            /// <param name="timeout">Tiempo de espera.</param>
            /// <param name="type">Tipo de comando.</param>
            /// <param name="ct">Token de cancelación.</param>
            public DapperEFCoreCommand(DbContext context, string text, object parameters, int? timeout, CommandType? type, CancellationToken ct)
            {
                var transaction = context.Database.CurrentTransaction?.GetDbTransaction();
                var commandType = type ?? CommandType.Text;
                var commandTimeout = timeout ?? context.Database.GetCommandTimeout() ?? 30;

                Definition = new CommandDefinition(
                    text,
                    parameters,
                    transaction,
                    commandTimeout,
                    commandType,
                    cancellationToken: ct
                );
            }

            /// <summary>
            /// Define el comando SQL.
            /// </summary>
            public CommandDefinition Definition { get; }

            /// <summary>
            /// Libera recursos del comando.
            /// </summary>
            public void Dispose()
            {
                // Nada que liberar manualmente por ahora.
            }
        }
    }
}