using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Context;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;
using IkinciElAracIhaleSistemiSonKullanici.EF;
using Microsoft.EntityFrameworkCore;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Derived
{
	public class IhaleStatuRepository : EfRepositoryBase<AracIhaleContext, IhaleStatu>, IIhaleStatuRepository
	{
		private readonly AracIhaleContext _context;

		public IhaleStatuRepository()
		{
		}

		public IhaleStatuRepository(AracIhaleContext context) : base(context)
		{
			_context = context;
		}

		public async Task<IhaleStatu> IhaleIdyeGoreIhaleStatuGetir(int id)
		{
			var ihale = await (from ai in _context.IhaleStatu
				join ih in _context.Ihale on ai.IhaleId equals ih.Id
				join a in _context.Statu on ai.StatuId equals a.StatuId
				where ai.IhaleId == id 
				      && ai.IsActive
					  && ai.IsDeleted == false
				select new IhaleStatu()
				{
					IhaleStatuId = ai.IhaleStatuId,
					StatuId = ai.StatuId,
					IhaleId = ai.IhaleId,
					Tarih = ai.Tarih,
					Statu = ai.Statu

				}).SingleOrDefaultAsync();

			return ihale;
		}

		public async Task<List<IhaleStatu>> IhaleStatuGetir()
		{
			var ihale = await (from ai in _context.IhaleStatu
				join ih in _context.Ihale on ai.IhaleId equals ih.Id
				join a in _context.Statu on ai.StatuId equals a.StatuId
				where ai.IsActive
				      && ai.IsDeleted == false
				select new IhaleStatu()
				{
					IhaleStatuId = ai.IhaleStatuId,
					StatuId = ai.StatuId,
					IhaleId = ai.IhaleId,
					Tarih = ai.Tarih,
					Statu = ai.Statu

				}).ToListAsync();

			return ihale;
		}
	}
}
