﻿using IkinciElAracIhaleSistemi.Entities.Entities;
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
		public async Task<AracIhale?> IhaledekiAracFiyatBilgisiniGetir(int ihaleId)
		{
			return (from ai in _context.AracIhale
					join ih in _context.Ihale on ai.IhaleId equals ih.Id
					join a in _context.Arac on ai.AracId equals a.Id
					where ai.IhaleId == ihaleId && ai.IsActive
					//orderby ai.MinimumAlimFiyati descending
					select new AracIhale()
					{
						Id = ai.Id,
						AracId = ai.AracId,
						IhaleId = ai.IhaleId,
						IhaleBaslangicFiyati = ai.IhaleBaslangicFiyati,
						MinimumAlimFiyati = ai.MinimumAlimFiyati
					}).SingleOrDefault();

		}
	}
}
