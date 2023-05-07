using Microsoft.EntityFrameworkCore;
using UCSC.ASE.StudentService.StudentModules;

namespace UCSC.ASE.StudentService.DatabaseModules
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
