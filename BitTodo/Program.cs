using BitTodo.Domain;
using BitTodo.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddDbContext<AppDbContext>(o 
    => o.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
services.AddDefaultIdentity<AppUser>().AddEntityFrameworkStores<AppDbContext>();
services.Configure<IdentityOptions>(o=>
{
    o.Password.RequiredUniqueChars = 3;
    o.Password.RequiredLength = 6;
    o.Password.RequireDigit = false;
    o.Password.RequireLowercase = true;
    o.Password.RequireUppercase = true;
    o.Password.RequireNonAlphanumeric = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
