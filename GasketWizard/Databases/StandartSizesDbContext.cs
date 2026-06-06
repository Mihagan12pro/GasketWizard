using GasketWizard.Domain.Shims;
using System.Data.Entity;

namespace GasketWizard
{
    public class StandartSizesDbContext : DbContext
    {
        public DbSet<Shim> Shims { get; set; }

        public StandartSizesDbContext() /*: base(new SQLiteConnection())*/
        {
            
        }
    }
}
