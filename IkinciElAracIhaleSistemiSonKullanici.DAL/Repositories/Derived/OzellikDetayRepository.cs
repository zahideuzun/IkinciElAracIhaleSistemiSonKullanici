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
	public class OzellikDetayRepository : EfRepositoryBase<AracIhaleContext, AracOzellik>, IOzellikDetayRepository
	{
		private readonly AracIhaleContext _context;

		public OzellikDetayRepository()
		{
		}

		public OzellikDetayRepository(AracIhaleContext context) : base(context)
		{
			_context = context;
		}

		public async Task<List<OzellikDetay>> AracOzellikleriniGetir(int id)
		{
			var ozellikListesi = (from ozd in _context.OzellikDetay
				join oz in _context.Ozellik on ozd.OzellikId equals oz.OzellikId
				join aoz in _context.AracOzellik on ozd.OzellikDetayId equals aoz.OzellikDetayId
				where aoz.AracId == id
				select new OzellikDetay()
				{
					OzellikDetayId = ozd.OzellikDetayId,
					OzellikId = ozd.OzellikId,
					OzellikDetayi = ozd.OzellikDetayi

				}).ToList();
			return ozellikListesi;
		}
	}
}
