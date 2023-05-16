using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Context;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;
using IkinciElAracIhaleSistemiSonKullanici.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			int ihaleyeAitUyeId = (_context.Ihale.FirstOrDefault(a => a.Id == id).UyeId);
			if (ihaleyeAitUyeId != null)
			{
				var araclar = (from a in _context.Arac
					join ast in _context.AracStatu on a.Id equals ast.AracId
					join st in _context.Statu on ast.StatuId equals st.StatuId
					join mr in _context.Marka on a.MarkaId equals mr.MarkaId
					join md in _context.Model on a.ModelId equals md.ModelId
					where a.UyeId == ihaleyeAitUyeId && a.IsActive && ast.IsActive
					select new Arac()
					{
						Id = a.Id,
						Plaka = a.Plaka,
						MarkaId = a.MarkaId,
						ModelId = a.ModelId,
						Km = a.Km,
						Yil = a.Yil 
					}).ToList();
				return araclar;
			}
			return null;
		}
	}
}
