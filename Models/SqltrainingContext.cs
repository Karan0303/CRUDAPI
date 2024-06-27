using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.Models;

public partial class SqltrainingContext : DbContext
{
    public SqltrainingContext()
    {
    }

    public SqltrainingContext(DbContextOptions<SqltrainingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<KStudent> KStudents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
       
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KStudent>(entity =>
        {
            entity.ToTable("K_Student");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FatherName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentGender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
