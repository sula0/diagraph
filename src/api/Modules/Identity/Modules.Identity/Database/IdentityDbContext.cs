using Diagraph.Infrastructure.Database;
using Diagraph.Infrastructure.EventSourcing;
using Diagraph.Infrastructure.ProcessManager.Contracts;
using Diagraph.Modules.Identity.ExternalIntegrations;
using Microsoft.EntityFrameworkCore;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Diagraph.Modules.Identity.Database;

public class IdentityDbContext : DbContextBase
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserProfile> Profiles { get; set; }
    public DbSet<Process> Processes { get; set; }
    public DbSet<SubscriptionCheckpoint> Checkpoints { get; set; }
    public DbSet<External> UserExternalIntegrations  { get; set; }
    
    public IdentityDbContext(DbContextOptions<IdentityDbContext> dbContextOptions) : base(dbContextOptions)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(IdentityDbContext).Assembly);
}