using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SearchCoach.Models
{
  public class SearchCoachContext : IdentityDbContext<ApplicationUser>
  {
    // include DbSets as needed
    public DbSet<Company> Companies { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<Status> Statuses { get; set; }

    public SearchCoachContext(DbContextOptions options) : base(options) { }
  }
}