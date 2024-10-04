using AulaEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using AulaEntityFramework.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration["AulaEntityFramework:ConnectionString"];
builder.Services.AddDbContext<MyDbContext>(
    o => o.UseSqlServer(connString)
);

// Registro dos serviços relacionados à camada de acesso ao repositório de dados
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddControllersWithViews();

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
