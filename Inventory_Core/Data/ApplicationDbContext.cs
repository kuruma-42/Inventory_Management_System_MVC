using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Inventory_Core.Models;

namespace Inventory_Core.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Inventory_Core.Models.SiteGroup> T00_MEMCO { get; set; }
        public DbSet<Inventory_Core.Models.Site> T00_SITE { get; set; }
        public DbSet<Inventory_Core.Models.CodeGroup> T00_CODE_GRP { get; set; }
        public DbSet<Inventory_Core.Models.Codes> T00_CODE { get; set; }
        public DbSet<Inventory_Core.Models.Devices> T00_DEVICE { get; set; }
        public DbSet<Inventory_Core.Models.Device_Logs> T00_DEVICE_LOG { get; set; }
        public DbSet<Inventory_Core.Models.Device_Sts> T00_DEVICE_STS { get; set; }
    }
}
