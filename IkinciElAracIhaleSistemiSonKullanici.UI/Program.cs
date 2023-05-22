using System.Configuration;
using AutoMapper;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.CacheHelper;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.Mapping;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Concrate;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Context;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Derived;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;
using IkinciElAracIhaleSistemiSonKullanici.UI.ApiProvider;
using Microsoft.AspNetCore.Authentication.Cookies;
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
			builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(o => o.LoginPath = new PathString("/Giris/Index"));

			#region MappingConfiguration

			builder.Services.AddAutoMapper(typeof(Program));
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MapProfile());
			});
			IMapper mapper = mapperConfig.CreateMapper();
			builder.Services.AddSingleton(mapper);


			#endregion

            #region MemoryCacheConfiguration

            builder.Services.AddMemoryCache();
            builder.Services.AddScoped<CacheHelper>();

            #endregion


			#region ProviderConfiguration
			builder.Services.AddHttpClient<GirisProvider>(x =>
			{
				x.BaseAddress = new Uri(builder.Configuration["apiBaseUrl"]);
				x.Timeout = TimeSpan.FromSeconds(120);
			});
			builder.Services.AddHttpClient<IhaleProvider>(x =>
			{
				x.BaseAddress = new Uri(builder.Configuration["apiBaseUrl"]);
				x.Timeout = TimeSpan.FromSeconds(120);
			});
			builder.Services.AddHttpClient<AracProvider>(x =>
			{
				x.BaseAddress = new Uri(builder.Configuration["apiBaseUrl"]);
				x.Timeout = TimeSpan.FromSeconds(120);
			});

			#endregion


			#region InstanceConfiguration
			builder.Services.AddScoped<IIhaleManager, IhaleManager>();
			builder.Services.AddScoped<IUyeManager, UyeManager>();
			builder.Services.AddScoped<IUyeRepository, UyeRepository>();
			builder.Services.AddScoped<IIhaleRepository, IhaleRepository>();
			builder.Services.AddScoped<IAracIhaleManager, AracIhaleManager>();
			builder.Services.AddScoped<IAracIhaleRepository, AracIhaleRepository>();
			builder.Services.AddScoped<IAracManager, AracManager>();
			builder.Services.AddScoped<IAracRepository, AracRepository>();
			builder.Services.AddScoped<IAracTeklifManager, AracTeklifManager>();
			builder.Services.AddScoped<IAracTeklifRepository, AracTeklifRepository>();
			builder.Services.AddScoped<ISayfaManager, SayfaManager>();
			builder.Services.AddScoped<ISayfaRepository, SayfaRepository>();
			builder.Services.AddScoped<IIhaleStatuManager, IhaleStatuManager>();
			builder.Services.AddScoped<IIhaleStatuRepository, IhaleStatuRepository>();

			#endregion


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
            app.UseAuthentication();
			app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Giris}/{action=Index}/{id?}");

            app.Run();
        }
    }
}