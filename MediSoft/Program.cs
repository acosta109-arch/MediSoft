using MediSoft.Components;
using MediSoft.DAL;
using MediSoft.Services;
using Microsoft.EntityFrameworkCore;
using Radzen;
using Microsoft.AspNetCore.Components.Authorization;

namespace MediSoft
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            // Connection string de sql
            var ConStr = builder.Configuration.GetConnectionString("ConStr");
            builder.Services.AddDbContext<Context>(options => options.UseSqlite(ConStr));
            builder.Services.AddBlazorBootstrap();

            // Inyecciones del service
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<UsuariosService>();
            builder.Services.AddScoped<AutentificacionService>();
            builder.Services.AddScoped<PacientesService>();
            builder.Services.AddScoped<CitasService>();
            builder.Services.AddScoped<DisponibilidadService>();
            builder.Services.AddScoped<DoctoresService>();
            builder.Services.AddScoped<NoticiasService>();

            // Add HttpContextAccessor
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
