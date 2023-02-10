using Microsoft.EntityFrameworkCore;
using Lourtec.ContactoMVC.DAL.DataContext;
using Lourtec.ContactoMVC.DAL.Contracts;
using Lourtec.ContactoMVC.Models;
using Lourtec.ContactoMVC.Logic.Service;
using Lourtec.ContactoMVC.DAL.Repositories;
using Lourtec.ContactoMVC.Logic.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbcontactoContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")); });

builder.Services.AddScoped<IGenericRepository<Contacto>, ContactoRepository>();
builder.Services.AddScoped<IContactoService, ContactoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
