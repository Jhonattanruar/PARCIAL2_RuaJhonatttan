using Microsoft.EntityFrameworkCore;
using PARCIAL2_RuaJhonattan.DAL.Entities;

namespace PARCIAL2_RuaJhonattan.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext>option): base(option)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PersonaNatural>().HasIndex(c => c.FullName).IsUnique();
        }
        public DbSet<PersonaNatural> PersonaNaturals { get; set; }
        
    }
}
