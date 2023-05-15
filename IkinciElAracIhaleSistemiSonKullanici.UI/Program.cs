using System.Configuration;
using AutoMapper;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.Mapping;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Concrate;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Context;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Derived;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;
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
			builder.Services.AddAutoMapper(typeof(Program));
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MapProfile());
			});
			IMapper mapper = mapperConfig.CreateMapper();
			builder.Services.AddDbContext<AracIhaleContext>(a => a.UseSqlServer(builder.Configuration.GetConnectionString("ConnSt")));
            builder.Services.AddHttpClient<GirisProvider>(x =>
            {
                x.BaseAddress = new Uri(builder.Configuration["apiBaseUrl"]);
            });
            builder.Services.AddHttpClient<IhaleProvider>(x =>
            {
                x.BaseAddress = new Uri(builder.Configuration["apiBaseUrl"]);
            });

            builder.Services.AddScoped<IIhaleManager, IhaleManager>();
            builder.Services.AddScoped<IUyeManager, UyeManager>();
            builder.Services.AddScoped<IIhaleRepository, IhaleRepository>();

			builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddHttpContextAccessor();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Giris}/{action=Index}/{id?}");

            app.Run();
        }
    }
}