using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemi.Entities.VM.Enum;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Context;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;
using IkinciElAracIhaleSistemiSonKullanici.DAL.UnitOfWork;
using IkinciElAracIhaleSistemiSonKullanici.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Derived
{
    public class IhaleRepository : EfRepositoryBase<AracIhaleContext, Ihale>, IIhaleRepository
    {
	    private readonly AracIhaleContext _context;
	    public IhaleRepository()
		{
		}
        public IhaleRepository(AracIhaleContext context) : base(context)
		{
			_context = context;
        }

		public async Task<Ihale> IdyeGoreIhaleGetir(int id)
		{
			var IdyeGoreIhale = TumIhaleleriGetir().Result.SingleOrDefault(a => a.Id == id);

			return IdyeGoreIhale;

		}

		public async Task<List<Ihale>> TumKurumsalIhaleleriGetir()
		{
			var kurumsalIhaleler = TumIhaleleriGetir().Result.Where(a => a.IhaleTuruId == (int)IhaleTurleri.Kurumsal).ToList();
			return kurumsalIhaleler;
		}
		public async Task<List<Ihale>> KurumsalFirmayaAitIhaleleriGetir(int id)
		{
			var kurumsalIhaleler = TumIhaleleriGetir().Result.Where(a => a.UyeId == id).ToList();
			
			return kurumsalIhaleler;
		}
		public async Task<List<Ihale>> BireyselIhaleleriGetir(int id)
		{
			var kurumsalIhaleler = TumIhaleleriGetir().Result.Where(a => a.IhaleTuruId == (int)IhaleTurleri.Bireysel).ToList();

			return kurumsalIhaleler;
		}


		public async Task<List<Ihale>> TumIhaleleriGetir()
		{
			return (from k in _context.Ihale
						 join it in _context.IhaleTuru on k.IhaleTuruId equals it.IhaleTuruId
						 join ist in _context.IhaleStatu on k.Id equals ist.IhaleId
						 join st in _context.Statu on ist.StatuId equals st.StatuId
						 where k.IsActive && ist.IsActive /*&& k.IhaleTuruId == (int)IhaleTurleri.Bireysel*/
					orderby k.CreatedDate descending
						 select new Ihale()
						 {
							 Id = k.Id,
							 IhaleAdi = k.IhaleAdi,
							 IhaleTuruId = k.IhaleTuru.IhaleTuruId, /*== (int)IhaleTurleri.Bireysel ? "Bireysel" : "Kurumsal",*/
							 IhaleTuru = k.IhaleTuru,
							 IhaleBaslangicTarihi = k.IhaleBaslangicTarihi,
							 IhaleBitisTarihi = k.IhaleBitisTarihi,
							 BaslangicSaat = k.BaslangicSaat,
							 BitisSaat = k.BitisSaat,
							 IhaleStatu = k.IhaleStatu,
						 }).ToList();

		}
    }

}
