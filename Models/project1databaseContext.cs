using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace testAzure
{
    public partial class project1databaseContext : DbContext
    {
        public project1databaseContext()
        {
        }

        public project1databaseContext(DbContextOptions<project1databaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<bus> Buses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:project1-server2.database.windows.net,1433;Initial Catalog=project1-database;Persist Security Info=False;User ID=administrador;Password=ELpapi2020;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasIndex(e => e.TicketId, "IX_Invoices_TicketId")
                    .IsUnique();

                entity.HasOne(d => d.Ticket)
                    .WithOne(p => p.Invoice)
                    .HasForeignKey<Invoice>(d => d.TicketId);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasIndex(e => e.BusId, "IX_Tickets_BusId");

                entity.HasIndex(e => e.UserId, "IX_Tickets_UserId");

                entity.HasOne(d => d.Bus)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.BusId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.UserId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
