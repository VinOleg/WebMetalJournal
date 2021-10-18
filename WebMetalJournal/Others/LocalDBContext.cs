using Microsoft.EntityFrameworkCore;
using WebMetalJournal.Models;

namespace WebMetalJournal.Others
{
    public class LocalDBContext : DbContext
    {
        public DbSet<Journal> Journals { get; set; }
        public DbSet<NomenclatureDir> NomenclaturesDir { get; set; }
        public DbSet<diameterDir> diametersDir { get; set; }

        public LocalDBContext(DbContextOptions<LocalDBContext> options)
             : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
