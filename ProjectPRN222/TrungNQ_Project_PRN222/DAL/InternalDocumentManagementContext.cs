using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TrungNQ_Project_PRN222.Models;

namespace TrungNQ_Project_PRN222.DAL;

public partial class InternalDocumentManagementContext : DbContext
{

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountPermission> AccountPermissions { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<DocumentStatus> DocumentStatuses { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }


    private readonly IConfiguration _configuration;

    public InternalDocumentManagementContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public InternalDocumentManagementContext(DbContextOptions<InternalDocumentManagementContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string connectionString = _configuration.GetConnectionString("InternalDocumentManagement");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA5A60CF157E2");

            entity.ToTable("Account");

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FullName).HasMaxLength(200);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber).HasMaxLength(15);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        modelBuilder.Entity<AccountPermission>(entity =>
        {
            entity.HasKey(e => e.AccountPermissionId).HasName("PK__AccountP__D1C60B8D77ADD779");

            entity.ToTable("AccountPermission");

            entity.HasOne(d => d.Account).WithMany(p => p.AccountPermissions)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__AccountPe__Accou__48CFD27E");

            entity.HasOne(d => d.Permission).WithMany(p => p.AccountPermissions)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("FK__AccountPe__Permi__49C3F6B7");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A0BC49B7EBF");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryName).HasMaxLength(100);
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__Document__1ABEEF0F3793B51C");

            entity.ToTable("Document");

            entity.Property(e => e.CreateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DocumentTitle).HasMaxLength(255);
            entity.Property(e => e.UpdateAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.Documents)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Document__Accoun__4316F928");

            entity.HasOne(d => d.Category).WithMany(p => p.Documents)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Document__Catego__440B1D61");

            entity.HasOne(d => d.DocumentStatus).WithMany(p => p.Documents)
                .HasForeignKey(d => d.DocumentStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Document__Docume__4222D4EF");
        });

        modelBuilder.Entity<DocumentStatus>(entity =>
        {
            entity.HasKey(e => e.DocumentStatusId).HasName("PK__Document__AFDCAF5D1E6BFDE7");

            entity.ToTable("DocumentStatus");

            entity.Property(e => e.DocumentStatusName).HasMaxLength(100);
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermissionId).HasName("PK__Permissi__EFA6FB2FE8D993EF");

            entity.ToTable("Permission");

            entity.Property(e => e.PermissionName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
