using BlazorApp.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(BlazorApp.Api.Startup))]

namespace BlazorApp.Api;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var connectionString = Environment.GetEnvironmentVariable("SqlConnectionString");
        builder.Services.AddDbContext<RefugeesDbContext>(
            options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
    }
}
