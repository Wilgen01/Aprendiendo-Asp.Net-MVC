using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AprendiendoAsp.Net.Models;

public partial class EjercicioAspNetContext : DbContext
{
    public EjercicioAspNetContext()
    {
    }

    public EjercicioAspNetContext(DbContextOptions<EjercicioAspNetContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Celular> Celulars { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-L21CB3D;Database=EjercicioAsp.Net; Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Celular>(entity =>
        {
            entity.HasKey(e => e.CelularId).HasName("PK_Celulares");

            entity.ToTable("Celular");

            entity.Property(e => e.Modelo)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("money");

            entity.HasOne(d => d.Marca).WithMany(p => p.Celulars)
                .HasForeignKey(d => d.MarcaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Celulares_Marca");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.ToTable("Marca");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
