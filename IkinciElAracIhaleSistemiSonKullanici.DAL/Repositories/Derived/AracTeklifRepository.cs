using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Context;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;
using IkinciElAracIhaleSistemiSonKullanici.DAL.UnitOfWork;
using IkinciElAracIhaleSistemiSonKullanici.EF;
using Microsoft.EntityFrameworkCore;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Derived
{
	public class AracTeklifRepository : EfRepositoryBase<AracIhaleContext,AracTeklif>, IAracTeklifRepository
	{
		private readonly AracIhaleContext _context;
		public AracTeklifRepository()
		{

		}
		public AracTeklifRepository(AracIhaleContext context) : base(context)
		{
			_context = context;
		}

		public Task<AracTeklif> IhaledekiAracaTeklifVerme(IhaleTeklifBilgileriDTO teklifDto)
		{
			var aracIdyeGoreAracIhaleTablosu =
				_context.AracIhale.SingleOrDefaultAsync(a => a.AracId == teklifDto.AracId && a.IsActive);


			//DataManager data = new DataManager();
			////data.GetAracTeklifRepository().AddAsync();

			_context.AracTeklif.Add(new AracTeklif()
			{
				AracIhaleId = aracIdyeGoreAracIhaleTablosu.Id,
				TeklifEdilenFiyat = teklifDto.TeklifEdilenFiyat,
				OnaylandiMi = false,
				UyeId = teklifDto.UyeId,
				TeklifTarihi = DateTime.Now
			});

			return null;
		}
	}
}
