using Microsoft.EntityFrameworkCore;
using UCSC.ASE.ReservationService.ReservationModules;
using UCSC.ASE.StudentService.StudentModules;

namespace UCSC.ASE.ReservationService.DatabaseModules
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
