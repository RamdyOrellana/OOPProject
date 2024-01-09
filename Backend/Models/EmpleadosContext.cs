using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Models;

public partial class EmpleadosContext : DbContext
{
    public EmpleadosContext()
    {
    }

    public EmpleadosContext(DbContextOptions<EmpleadosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Registro> Registros { get; set; }

    public virtual DbSet<SubArea> SubAreas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-Q1VRBTO; Database=Empleados; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.AreaId).HasName("PK__Area__70B820486517056C");

            entity.ToTable("Area");

            entity.Property(e => e.AreaId).ValueGeneratedNever();
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.Pais).WithMany(p => p.Areas)
                .HasForeignKey(d => d.PaisId)
                .HasConstraintName("FK__Area__PaisId__5070F446");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.PaisId).HasName("PK__Pais__B501E1855C395783");

            entity.Property(e => e.PaisId).ValueGeneratedNever();
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Registro>(entity =>
        {
            entity.HasKey(e => e.IdRegistro);

            entity.ToTable("registro");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaContratación)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.País)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SubÁrea)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TipoDocumento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Área)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SubArea>(entity =>
        {
            entity.HasKey(e => e.SubAreaId).HasName("PK__SubArea__BD6064EA35F3E665");

            entity.ToTable("SubArea");

            entity.Property(e => e.SubAreaId).ValueGeneratedNever();
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.Area).WithMany(p => p.SubAreas)
                .HasForeignKey(d => d.AreaId)
                .HasConstraintName("FK__SubArea__AreaId__534D60F1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
