using System.Reflection;
using Ardalis.SharedKernel;
using Damon.ClenArch.Core.ContributorAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Damon.ClenArch.Infrastructure.Data;
public class AppDbContext : DbContext
{
  private readonly IDomainEventDispatcher? _dispatcher;
  private readonly ILogger<AppDbContext>? _logger;

  public AppDbContext(DbContextOptions<AppDbContext> options,
    IDomainEventDispatcher? dispatcher, ILogger<AppDbContext>? logger)
      : base(options)
  {
    _dispatcher = dispatcher;
    _logger = logger;
  }

  public DbSet<Contributor> Contributors => Set<Contributor>();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {
    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_dispatcher == null) return result;

    // dispatch events only if save was successful
    var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
        .Select(e => e.Entity)
        .Where(e => e.DomainEvents.Any())
        .ToArray();

    if (_logger == null) return result;
    _logger.LogInformation("Entities with events: {entitiesWithEventsCount}", entitiesWithEvents.Length);
    _logger.LogInformation("Dispatching events: {eventsCount}", entitiesWithEvents.SelectMany(e => e.DomainEvents).Count());

    return result;
  }

  public override int SaveChanges() =>
        SaveChangesAsync().GetAwaiter().GetResult();
}
