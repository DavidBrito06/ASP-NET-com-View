using br.com.fiap.alert.Models;
using Microsoft.EntityFrameworkCore;

namespace br.com.fiap.alert.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<AlertModel> Alerts { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
        protected DatabaseContext()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlertModel>(entity =>
            {
                entity.ToTable("TB_ALERT");
                entity.HasKey(e => e.AlertId);
                entity.Property(e => e.TypeAlert);
                entity.Property(e => e.Message);
                entity.Property(e => e.Coords);
                entity.Property(e => e.Author);

                //Adicionar migracao Add-Migration nomeMigration

                //Update-Database para efetivar a migracao

            }
            );

            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.ToTable("TB_USER");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);
                entity.Property(e => e.Email);
                entity.Property(e => e.PasswordHash);
            }
            );
        }
    }
}


