using bpkp_be.Models;
using Microsoft.EntityFrameworkCore;

namespace bpkp_be.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<TrBpkb> tr_bpkp { get; set; }
        public DbSet<MsStorageLocation> ms_storage_location { get; set; }
        public DbSet<MsUser> ms_user { get; set; }
    }
}
