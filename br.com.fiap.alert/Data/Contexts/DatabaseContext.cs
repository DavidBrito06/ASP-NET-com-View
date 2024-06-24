using br.com.fiap.alert.Models;
using Microsoft.EntityFrameworkCore;

namespace br.com.fiap.alert.Data.Contexts
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<AlertModel> Alerts { get; set; }
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
        }
    }
}


