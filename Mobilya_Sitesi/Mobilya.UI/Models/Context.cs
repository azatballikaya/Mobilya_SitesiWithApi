using Microsoft.EntityFrameworkCore;

namespace Mobilya_Sitesi.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-NOPPPVL\\SQLEXPRESS; database=Mobilya; integrated security=true; TrustServerCertificate = True;");
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Category { get; set; }

    }
}
