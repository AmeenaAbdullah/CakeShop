using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CakesShop.Models
{
    public partial class CakesShopManagementSystemContext : DbContext
    {
        public CakesShopManagementSystemContext()
        {
        }

        public CakesShopManagementSystemContext(DbContextOptions<CakesShopManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cake> Cakes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=CakesShopManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }
        public override int SaveChanges()
        {
            var tracker = ChangeTracker;
            foreach(var entity in tracker.Entries())
            {
                if(entity.Entity is FullAuditModel)
                {
                    var refEntity = entity.Entity as FullAuditModel;
                    switch(entity.State)
                    {
                        case EntityState.Deleted:
                         case EntityState.Added:
                            refEntity.CreatedDate = DateTime.Now;
                            refEntity.CreatedByUserId = "1";
                         break;
                        case EntityState.Modified:
                            refEntity.LastModifiedUserId = "1";
                            refEntity.LastModifiedDate = DateTime.Now;
                            break;
                        default:
                            break;

                    }
                }
                else if (entity.Entity is FullAudit_User)
                {
                    var refEntity = entity.Entity as FullAudit_User;
                    switch (entity.State)
                    {
                        case EntityState.Deleted:
                        case EntityState.Added:
                            refEntity.CreatedDate = DateTime.Now;
                            break;
                        case EntityState.Modified:
                            refEntity.LastModifiedDate = DateTime.Now;
                            break;
                        default:
                            break;

                    }
                }


            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cake>(entity =>
            {
                entity.ToTable("Cake");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.Pond).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Gmail).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
