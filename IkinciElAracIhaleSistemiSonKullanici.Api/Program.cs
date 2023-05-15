using AutoMapper;
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
            builder.Services.AddAutoMapper(typeof(Program));
            var mapperConfig = new MapperConfiguration(mc =>
            {
	            mc.AddProfile(new MapProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);
			builder.Services.AddScoped<IUyeManager, UyeManager>();
            builder.Services.AddScoped<IIhaleRepository, IhaleRepository>();
			builder.Services.AddScoped<IIhaleManager, IhaleManager>();

            builder.Services.AddDbContext<AracIhaleContext>(a => a.UseSqlServer(builder.Configuration.GetConnectionString("ConnSt")));
           
            builder.Services.AddSwaggerGen(a =>
            {
                a.SwaggerDoc("v1", new OpenApiInfo() { Title = "AracIhale", Version = "v1" });
            });

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