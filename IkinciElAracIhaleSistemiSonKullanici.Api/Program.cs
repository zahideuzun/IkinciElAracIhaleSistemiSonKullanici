using AutoMapper;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.CacheHelper;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.Mapping;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Concrate;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Context;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Derived;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace IkinciElAracIhaleSistemiSonKullanici.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddDbContext<AracIhaleContext>(a => a.UseSqlServer(builder.Configuration.GetConnectionString("ConnSt")));


			//todo test 3 ihale arac teklifi kontrol? 
			//todo refac yap iki projeye de
			//todo ihale durumlarini timer ile guncelle? 


			#region MappingConfiguration

			builder.Services.AddAutoMapper(typeof(Program));
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MapProfile());
			});
			IMapper mapper = mapperConfig.CreateMapper();
			builder.Services.AddSingleton(mapper);


			#endregion

			#region IoC

			builder.Services.AddScoped<IUyeManager, UyeManager>();
			builder.Services.AddScoped<IUyeRepository, UyeRepository>();
			builder.Services.AddScoped<IIhaleRepository, IhaleRepository>();
			builder.Services.AddScoped<IIhaleManager, IhaleManager>();
			builder.Services.AddScoped<IAracIhaleManager, AracIhaleManager>();
			builder.Services.AddScoped<IAracIhaleRepository, AracIhaleRepository>();
			builder.Services.AddScoped<IAracManager, AracManager>();
			builder.Services.AddScoped<IAracRepository, AracRepository>();
			builder.Services.AddScoped<IAracTeklifManager, AracTeklifManager>();
			builder.Services.AddScoped<IAracTeklifRepository, AracTeklifRepository>();
			builder.Services.AddScoped<ISayfaManager, SayfaManager>();
			builder.Services.AddScoped<ISayfaRepository, SayfaRepository>();
			builder.Services.AddScoped<IOzellikDetayRepository, OzellikDetayRepository>();
			builder.Services.AddScoped<IOzellikDetayManager, OzellikDetayManager>();
			builder.Services.AddScoped<IIhaleStatuManager, IhaleStatuManager>();
			builder.Services.AddScoped<IIhaleStatuRepository, IhaleStatuRepository>();
			

            #endregion

            #region MemoryCacheConfiguration

            builder.Services.AddMemoryCache();
            builder.Services.AddScoped<CacheHelper>();

            #endregion

            #region Swagger

            builder.Services.AddSwaggerGen(a =>
			{
				a.SwaggerDoc("v1", new OpenApiInfo() { Title = "AracIhale", Version = "v1" });
			});

			#endregion


			#region Timer

			#endregion


			var app = builder.Build();

            

            // Configure the HTTP request pipeline.

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "swagger");
            });

            app.MapControllers();

            app.Run();
        }
    }
}