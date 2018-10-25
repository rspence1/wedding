using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WeddingApi.ModelsDBO
{
    public partial class weddingContext : DbContext
    {
        public weddingContext()
        {
        }

        public weddingContext(DbContextOptions<weddingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Guest> Guest { get; set; }
        public virtual DbSet<Invitation> Invitation { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(250);

                entity.Property(e => e.AttendingState)
                    .HasColumnName("attendingState")
                    .HasDefaultValueSql("((-1))");

                entity.Property(e => e.InvitationId).HasColumnName("invitationId");

                entity.Property(e => e.IsPlusOne).HasColumnName("isPlusOne");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("ntext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(150);

                entity.HasOne(d => d.Invitation)
                    .WithMany(p => p.Guest)
                    .HasForeignKey(d => d.InvitationId)
                    .HasConstraintName("FK_Guest_Invitation");
            });

            modelBuilder.Entity<Invitation>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.LoginCode)
                    .IsRequired()
                    .HasColumnName("loginCode")
                    .HasMaxLength(8);

                entity.Property(e => e.Sent)
                    .HasColumnName("sent")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastLogin)
                    .HasColumnName("lastLogin")
                    .HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(64);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasColumnName("salt")
                    .HasMaxLength(128);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50);
            });
        }
    }
}
