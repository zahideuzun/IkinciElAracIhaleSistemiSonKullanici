using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Context;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;
using IkinciElAracIhaleSistemiSonKullanici.EF;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Derived
{
	public class AracRepository : EfRepositoryBase<AracIhaleContext, Arac>, IAracRepository
	{
		private readonly AracIhaleContext _context;
		public AracRepository()
		{
		}
		public AracRepository(AracIhaleContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<Arac>> IhaledekiAraclariGetir(int id)
		{
			var ihale = _context.Ihale.FirstOrDefault(a => a.Id == id);
			var ihaleyeAitUyeId = ihale.UyeId;

			if (ihaleyeAitUyeId == null) return null;
			var araclar = (from a in _context.Arac
				join ast in _context.AracStatu on a.Id equals ast.AracId
				join st in _context.Statu on ast.StatuId equals st.StatuId
				join mr in _context.Marka on a.MarkaId equals mr.MarkaId
				join ai in _context.AracIhale on a.Id equals ai.AracId
				join md in _context.Model on a.ModelId equals md.ModelId
				where a.UyeId == ihaleyeAitUyeId 
				      && a.IsActive 
				      && ast.IsActive 
				      && ai.AracId == a.Id 
				      && ai.IsActive
				select new Arac()
				{
					Id = a.Id,
					Plaka = a.Plaka,
					MarkaId = a.MarkaId,
					Marka = a.Marka,
					Model = a.Model,
					ModelId = a.ModelId,
					Km = a.Km,
					Yil = a.Yil 
				}).ToList();
			return araclar;
		}
	}
}
