using ApiRestaurant.Infrastructure.Identity;
using ApiRestaurant.Infrastructure.Persistence;
using ApiRestaurant.Core.Application;
using ApiRestaurant.Infrastructure.Identity.Entities;
using ApiRestaurant.Infrastructure.Identity.Seeds;
using ApiRestaurant.WebApp.WebApi.Extensions;
using Microsoft.AspNetCore.Identity;
using ApiRestaurant.WebApp.WebApi.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerGen();
builder.Services.AddSession();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSwaggerExtension();
builder.Services.AddApiVersioningExtension();
builder.Services.ConfigureService(builder.Configuration);
builder.Services.AddInfrastructurePersistence(builder.Configuration);
builder.Services.AddCoreApplication();





var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var provider = scope.ServiceProvider;
    try
    {
        var userManager = provider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

        await DefaultRoles.SeedAsync(userManager, roleManager);
        await DefaultBasicUser.SeedAsync(userManager, roleManager);
        await DefaultSuperAdminUser.SeedAsync(userManager, roleManager);
    }
    catch (Exception e)
    {

    }
}
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseHealthChecks("/health");
app.UseSession();

app.MapControllers();

app.Run();
