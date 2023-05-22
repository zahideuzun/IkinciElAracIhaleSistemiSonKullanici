using IkinciElAracIhaleSistemiSonKullanici.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using IkinciElAracIhaleSistemi.Entities.VM.Enum;
using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemiSonKullanici.Console
{
	public class Program
	{
		static async Task Main(string[] args)
		{
			//todo bu katman apiye cikarilir
			var connectionString = "server=DESKTOP-L9HHG11\\SQLEXPRESS;database=AracIhaleSistemiDB;user id=sa;password=sa;multipleactiveresultsets=true;trustservercertificate=true;";
			var dbContextOptions = new DbContextOptionsBuilder<AracIhaleContext>()
				.UseSqlServer(connectionString)
				.Options;

			
			using var dbContext = new AracIhaleContext(dbContextOptions);

			var ihaleler = await dbContext.Ihale
				.Where(ihale => ihale.IsActive && !ihale.IsDeleted)
				.ToListAsync();

			var now = DateTime.UtcNow.ToLocalTime();
			var currentDate = now.Date; 
			var currentTime = now.TimeOfDay; 

			foreach (var ihale in ihaleler)
			{
				var ihaleStatu = await dbContext.IhaleStatu
					.Where(statu => statu.IsActive && !statu.IsDeleted && ihale.Id == statu.IhaleId)
					.ToListAsync();

				if (currentDate <= ihale.IhaleBaslangicTarihi.Date && currentTime <= ihale.BaslangicSaat)
				{
					foreach (var ihalestatu in ihaleStatu)
					{
						ihalestatu.StatuId = (int)IhaleStatuleri.Baslamadi;
					}
				}

				if (ihale.IhaleBaslangicTarihi.Date <= currentDate && currentTime >= ihale.BaslangicSaat && ihale.IhaleBitisTarihi.Date >= currentDate && ihale.BitisSaat >= currentTime)
				{
					foreach (var ihalestatu in ihaleStatu)
					{
						ihalestatu.StatuId = (int)IhaleStatuleri.Basladi;
					}
				}

				
				if (ihale.IhaleBitisTarihi.Date <= now && currentTime >= ihale.BitisSaat)
				{
					foreach (var ihalestatu in ihaleStatu)
					{
						ihalestatu.StatuId = (int)IhaleStatuleri.Bitti;
					};
				}
			}

			await dbContext.SaveChangesAsync();

			System.Console.WriteLine("İhale durumları güncellendi.");
			System.Console.ReadKey();
		}
	}
}