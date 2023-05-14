using System.Configuration;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Concrate;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Context;
using IkinciElAracIhaleSistemiSonKullanici.UI.ApiProvider;
using Microsoft.EntityFrameworkCore;

namespace IkinciElAracIhaleSistemiSonKullanici.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AracIhaleContext>(a => a.UseSqlServer(builder.Configuration.GetConnectionString("ConnSt")));
            builder.Services.AddHttpClient<GirisProvider>(x =>
            {
                x.BaseAddress = new Uri(builder.Configuration["apiBaseUrl"]);
            });

            builder.Services.AddScoped<IUyeManager, UyeManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Giris}/{action=Index}/{id?}");

            app.Run();
        }
    }
}