using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirstAspCore.Models;

public partial class WatchListContext : DbContext
{
    public WatchListContext()
    {
    }

    public WatchListContext(DbContextOptions<WatchListContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAnimeList> TblAnimeLists { get; set; }

    public virtual DbSet<TblStatus> TblStatuses { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAnimeList>(entity =>
        {
            entity.ToTable("tblAnimeList");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Genre)
                .HasMaxLength(50)
                .HasColumnName("GENRE");
            entity.Property(e => e.Isfavourite).HasColumnName("ISFAVOURITE");
            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .HasColumnName("NAME");
            entity.Property(e => e.Rating).HasColumnName("RATING");
            entity.Property(e => e.Sataus).HasColumnName("SATAUS");

            entity.HasOne(d => d.SatausNavigation).WithMany(p => p.TblAnimeLists)
                .HasForeignKey(d => d.Sataus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblAnimeList_tblStatus");
        });

        modelBuilder.Entity<TblStatus>(entity =>
        {
            entity.HasKey(e => e.Sid);

            entity.ToTable("tblStatus");

            entity.Property(e => e.Sid).ValueGeneratedNever();
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("STATUS");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tblUser");

            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Contact)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("contact");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
