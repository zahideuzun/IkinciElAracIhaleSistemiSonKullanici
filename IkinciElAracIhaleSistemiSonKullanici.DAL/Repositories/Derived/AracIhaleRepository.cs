using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Context;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;
using IkinciElAracIhaleSistemiSonKullanici.EF;
using Microsoft.EntityFrameworkCore;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Derived
{
	public class AracIhaleRepository : EfRepositoryBase<AracIhaleContext, AracIhale>, IAracIhaleRepository
	{
		private readonly AracIhaleContext _context;
		public AracIhaleRepository()
		{

		}
		public AracIhaleRepository(AracIhaleContext context) : base(context)
		{
			_context = context;
		}

		public Task<AracIhale?> AracIdyeGoreIhaledekiAracFiyatBilgisiniGetir(int aracId)
		{
			var ihale = (from ai in _context.AracIhale
				join ih in _context.Ihale on ai.IhaleId equals ih.Id
				join a in _context.Arac on ai.AracId equals a.Id
				where ai.AracId == aracId && ai.IsActive
				select new AracIhale()
				{
					Id = ai.Id,
					AracId = ai.AracId,
					IhaleId = ai.IhaleId,
					IhaleBaslangicFiyati = ai.IhaleBaslangicFiyati,
					MinimumAlimFiyati = ai.MinimumAlimFiyati
				}).SingleOrDefaultAsync();

			return ihale;
		}

		public async Task<List<AracIhale?>> IhaleIdyeGoreIhaledekiAracFiyatBilgileriniGetir(int ihaleId)
		{
			var ihale= await (from ai in _context.AracIhale
					join ih in _context.Ihale on ai.IhaleId equals ih.Id
					join a in _context.Arac on ai.AracId equals a.Id
					where ai.IhaleId == ihaleId && ai.IsActive
					select new AracIhale()
					{
						Id = ai.Id,
						AracId = ai.AracId,
						IhaleId = ai.IhaleId,
						IhaleBaslangicFiyati = ai.IhaleBaslangicFiyati,
						MinimumAlimFiyati = ai.MinimumAlimFiyati
					}).ToListAsync();
			
			return ihale;
		}
	}
}
