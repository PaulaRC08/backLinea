using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BCProyecto.Models
{
    public partial class BDCOLEGIOContext : DbContext
    {

        public BDCOLEGIOContext(DbContextOptions<BDCOLEGIOContext> options)
            : base(options)
        {
        }
        public virtual DbSet<TbCentroFormacion> TbCentroFormacion { get; set; } = null!;
        public virtual DbSet<TbClase> TbClases { get; set; } = null!;
        public virtual DbSet<TbEstudiante> TbEstudiantes { get; set; } = null!;
        public virtual DbSet<TbEstudianteclase> TbEstudianteclases { get; set; } = null!;
        public virtual DbSet<TbUsuario> TbUsuarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbCentroFormacion>(entity =>
            {
                entity.HasKey(e => e.Idcentro);

                entity.ToTable("TB_CENTROFORMACION");

                entity.Property(e => e.Nombrecentro)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRECENTRO");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION");

            });

            modelBuilder.Entity<TbClase>(entity =>
            {
                entity.HasKey(e => e.Idclase);

                entity.ToTable("TB_CLASES");

                entity.Property(e => e.Idclase).HasColumnName("IDCLASE");

                entity.Property(e => e.Activo).HasColumnName("ACTIVO");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CODIGO");

                entity.Property(e => e.Creditos).HasColumnName("CREDITOS");

                entity.Property(e => e.Descripcion)
                    .HasColumnType("text")
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Temario)
                    .HasColumnType("text")
                    .HasColumnName("TEMARIO");

                entity.Property(e => e.Nombreclase)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRECLASE");
            });

            modelBuilder.Entity<TbEstudiante>(entity =>
            {
                entity.HasKey(e => e.Idestudiante);

                entity.ToTable("TB_ESTUDIANTES");

                entity.Property(e => e.Idestudiante).HasColumnName("IDESTUDIANTE");

                entity.Property(e => e.Activo).HasColumnName("ACTIVO");

                entity.Property(e => e.Apellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDO");

                entity.Property(e => e.Codigoestudiante)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CODIGOESTUDIANTE");

                entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRE");

                entity.Property(e => e.Numeroidentificacion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NUMEROIDENTIFICACION");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.TbEstudiantes)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TB_ESTUDIANTES_TB_USUARIOS");
            });

            modelBuilder.Entity<TbEstudianteclase>(entity =>
            {
                entity.HasKey(e => e.Idestudianteclases)
                    .HasName("PK_ESTUDIANTECLASES");

                entity.ToTable("TB_ESTUDIANTECLASES");

                entity.Property(e => e.Idestudianteclases).HasColumnName("IDESTUDIANTECLASES");

                entity.Property(e => e.Idclase).HasColumnName("IDCLASE");

                entity.Property(e => e.Idestudiante).HasColumnName("IDESTUDIANTE");

                entity.HasOne(d => d.IdclaseNavigation)
                    .WithMany(p => p.TbEstudianteclases)
                    .HasForeignKey(d => d.Idclase)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TB_ESTUDIANTECLASES_TB_CLASES");

                entity.HasOne(d => d.IdestudianteNavigation)
                    .WithMany(p => p.TbEstudianteclases)
                    .HasForeignKey(d => d.Idestudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TB_ESTUDIANTECLASES_TB_ESTUDIANTES");
            });

            modelBuilder.Entity<TbUsuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario);

                entity.ToTable("TB_USUARIOS");

                entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");

                entity.Property(e => e.Administrador).HasColumnName("ADMINISTRADOR");

                entity.Property(e => e.Activo).HasColumnName("ACTIVO");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Pass)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("PASS");

                entity.Property(e => e.TokenCamPass)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("TOKENRECPASS");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHACREACION");

            });

            modelBuilder.Entity<TbHistoryLogin>(entity =>
            {
                entity.HasKey(e => e.IdLogin);

                entity.ToTable("TB_HISTORY_INICIOSESION");

                entity.Property(e => e.IdLogin).HasColumnName("IDINICIOSESION");

                entity.Property(e => e.Idusuario).HasColumnName("IDUSUARIO");

                entity.Property(e => e.Usuario)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USUARIO");

                entity.Property(e => e.IPEquipo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IPEQUIPO");
                entity.Property(e => e.NombreEquipo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NOMBREEQUIPO");

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("FECHA");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
