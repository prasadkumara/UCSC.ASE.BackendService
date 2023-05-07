using Microsoft.EntityFrameworkCore;
using UCSC.ASE.CampaignService.CampaignModules;

namespace UCSC.ASE.CampaignService.DatabaseModules
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<PromotionsDetail> PromotionsDetails { get; set; }
    }
}
