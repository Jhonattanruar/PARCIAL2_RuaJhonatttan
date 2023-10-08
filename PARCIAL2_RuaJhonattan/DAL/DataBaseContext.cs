using Microsoft.EntityFrameworkCore;
using PARCIAL2_RuaJhonattan.DAL.Entities;

namespace PARCIAL2_RuaJhonattan.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext>option): base(option)
        {
            
        }
        public DbSet<PersonaNatural> PersonaNaturals { get; set; }
        
    }
}
