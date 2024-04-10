using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Damon.ClenArch.Core.Interfaces;
using Damon.ClenArch.Core.Services;
using Damon.ClenArch.Infrastructure.Data;
using Damon.ClenArch.Infrastructure.Data.Queries;
using Damon.ClenArch.Infrastructure.Email;
using Damon.ClenArch.UseCases.Contributors.List;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Damon.ClenArch.Infrastructure;
public static class InfrastructureServiceExtensions
{
  public static IServiceCollection AddInfrastructureServices(
    this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger)
  {
    string? connectionString = config.GetConnectionString("MysqlConnection");
    Guard.Against.Null(connectionString,message: "Connection string is null");
    services.AddDbContext<AppDbContext>(options =>
     options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

    services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
    services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
    services.AddScoped<IListContributorsQueryService, ListContributorsQueryService>();
    services.AddScoped<IDeleteContributorService, DeleteContributorService>();
    services.AddScoped<IEditContributorService, EditContributorService>();


    services.Configure<MailserverConfiguration>(config.GetSection("Mailserver"));

    logger.LogInformation("{Project} services registered", "Infrastructure");

    return services;
  }
}
