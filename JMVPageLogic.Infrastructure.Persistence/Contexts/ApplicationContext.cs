using JMVPageLogic.Core.Domain.Common;
using JMVPageLogic.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JMVPageLogic.Infrastructure.Identity.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Actividades> Actividades { get; set; }
        public DbSet<Biblioteca> Biblioteca { get; set; }
        public DbSet<Centro> Centro { get; set; }
        public DbSet<Comunidad> Comunidad { get; set; }
        public DbSet<Estatus> Estatus { get; set; }
        public DbSet<Publicacion> Publicacion { get; set; }
        public DbSet<Recordatorio> Recordatorio { get; set; }
        public DbSet<Tipo> Tipo { get; set; }
        public DbSet<Valor> Valor { get; set; }
        public DbSet<Vocal> Vocal { get; set; }
        public DbSet<Vocalia> Vocalia { get; set; }
        public DbSet<VocalValor> VocalValor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Configuraciones de Tablas
            modelBuilder.Entity<Actividades>().ToTable("Actividades");
            modelBuilder.Entity<Biblioteca>().ToTable("Biblioteca");
            modelBuilder.Entity<Centro>().ToTable("Centro");
            modelBuilder.Entity<Comunidad>().ToTable("Comunidad");
            modelBuilder.Entity<Estatus>().ToTable("Estatus");
            modelBuilder.Entity<Publicacion>().ToTable("Publicacion");
            modelBuilder.Entity<Recordatorio>().ToTable("Recordatorio");
            modelBuilder.Entity<Tipo>().ToTable("Tipo");
            modelBuilder.Entity<Valor>().ToTable("Valor");
            modelBuilder.Entity<Vocal>().ToTable("Vocal");
            modelBuilder.Entity<Vocalia>().ToTable("Vocalia");
            modelBuilder.Entity<VocalValor>().ToTable("VocalValor");
            #endregion

            #region Configuraciones de Claves Primarias
            // Actividades tiene clave compuesta
            modelBuilder.Entity<Actividades>().HasKey(a => a.Id);

            // Biblioteca usa Ruta_doc como clave primaria
            modelBuilder.Entity<Biblioteca>().HasKey(b => b.Id);

            // Centro usa Nombre como clave primaria
            modelBuilder.Entity<Centro>().HasKey(c => c.Id);

            // Comunidad usa Nombre como clave primaria
            modelBuilder.Entity<Comunidad>().HasKey(c => c.Id);

            // Estatus usa Nombre como clave primaria
            modelBuilder.Entity<Estatus>().HasKey(e => e.Id);

            // Publicacion usa IMG como clave primaria
            modelBuilder.Entity<Publicacion>().HasKey(p => p.Id);

            // Recordatorio tiene clave compuesta
            modelBuilder.Entity<Recordatorio>().HasKey(r => r.Id);

            // Tipo usa Nombre como clave primaria
            modelBuilder.Entity<Tipo>().HasKey(t => t.Id);

            // Valor usa Nombre como clave primaria
            modelBuilder.Entity<Valor>().HasKey(v => v.Id);

            // Vocal tiene clave compuesta
            modelBuilder.Entity<Vocal>().HasKey(v => v.Id);

            // Vocalia usa Nombre como clave primaria
            modelBuilder.Entity<Vocalia>().HasKey(v => v.Id);

            // VocalValor tiene clave compuesta
            modelBuilder.Entity<VocalValor>().HasKey(vv => vv.Id);
            #endregion

            #region Configuraciones de Relaciones
            // Relación Actividades - Publicacion
            modelBuilder.Entity<Publicacion>()
                .HasMany(p => p.Actividades)
                .WithOne(a => a.Publicacion)
                .HasForeignKey(a => a.Id_Publicacion)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Actividades - Centro
            modelBuilder.Entity<Centro>()
                .HasMany(c => c.Actividades)
                .WithOne(a => a.Centro)
                .HasForeignKey(a => a.Id_Centro)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Centro - Estatus
            modelBuilder.Entity<Centro>()
                .HasOne(c => c.Estatus)
                .WithMany()
                .HasForeignKey(c => c.Id)  
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Comunidad - Centro
            modelBuilder.Entity<Comunidad>()
                .HasOne(c => c.Centro)
                .WithMany()
                .HasForeignKey(c => c.CentroId)  
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Comunidad - Estatus
            modelBuilder.Entity<Comunidad>()
                .HasOne(c => c.Estatus)
                .WithMany()
                .HasForeignKey(c => c.EstatusId)  
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Publicacion - Centro
            modelBuilder.Entity<Centro>()
                .HasMany(c => c.Publicaciones)
                .WithOne(p => p.Centro)
                .HasForeignKey(p => p.Id_Centro)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Recordatorio - Publicacion
            modelBuilder.Entity<Recordatorio>()
                .HasOne(r => r.Publicacion)
                .WithMany()
                .HasForeignKey(r => r.IdPublicacion)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Vocal - Centro
            modelBuilder.Entity<Vocal>()
                .HasOne(v => v.Centro)
                .WithMany()
                .HasForeignKey(v => v.IdCentro)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación Vocal - Vocalia
            modelBuilder.Entity<Vocal>()
                .HasOne(v => v.Vocalia)
                .WithMany()
                .HasForeignKey(v => v.IdVocalia)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Vocalia - Tipo
            modelBuilder.Entity<Vocalia>()
                .HasOne(v => v.Tipo)
                .WithMany()
                .HasForeignKey(v => v.Id_Tipovocalia)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación muchos a muchos Vocal-Valor
            modelBuilder.Entity<VocalValor>()
                .HasOne(vv => vv.Vocal)
                .WithMany(v => v.VocalValores)
                .HasForeignKey(vv => vv.VocalId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VocalValor>()
                .HasOne(vv => vv.Valor)
                .WithMany(v => v.VocalValores)
                .HasForeignKey(vv => vv.ValorId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Configuraciones de Propiedades
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(IAuditableEntity).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(IAuditableEntity.CreatedDate))
                        .HasDefaultValueSql("GETDATE()");

                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(IAuditableEntity.ModifiedDate))
                        .IsRequired(false);

                    modelBuilder.Entity(entityType.ClrType)
                        .Property(nameof(IAuditableEntity.DeletedDate))
                        .IsRequired(false);
                }
            }
            #endregion
        }
    }
}