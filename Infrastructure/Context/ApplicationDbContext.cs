using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base((options))
        {
            
        }

        // Create table from DOMAIN Models
        // Set ka matlab k humein Get and Set ki need nahn hum direct Set hi krengy humesha

        public DbSet<Property> Properties => Set<Property>();
        public DbSet<Image> Images => Set<Image>();

    }
}
