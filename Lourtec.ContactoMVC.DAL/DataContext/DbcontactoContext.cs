using System;
using System.Collections.Generic;
using Lourtec.ContactoMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Lourtec.ContactoMVC.DAL.DataContext;

public partial class DbcontactoContext : DbContext
{
    public DbcontactoContext()
    {
    }

    public DbcontactoContext(DbContextOptions<DbcontactoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contacto> Contactos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
    {
    
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.IdContacto).HasName("PK__Contacto__A4D6BBFAF3764178");

            entity.ToTable("Contacto");

            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
