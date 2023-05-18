using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.Results;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.Results.Bases;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Context;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;
using IkinciElAracIhaleSistemiSonKullanici.DAL.UnitOfWork;
using IkinciElAracIhaleSistemiSonKullanici.EF;
using IkinciElAracIhaleSistemiSonKullanici.UI.Validations;
using Microsoft.EntityFrameworkCore;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Derived
{
	public class AracTeklifRepository : EfRepositoryBase<AracIhaleContext, AracTeklif>, IAracTeklifRepository
	{
		private readonly AracIhaleContext _context;
		public AracTeklifRepository()
		{

		}
		public AracTeklifRepository(AracIhaleContext context) : base(context)
		{
			_context = context;
		}

        public async Task<List<AracTeklif>> AracaVerilenTeklifleriGetir(int aracId)
        {
            var ihale =  await (from at in _context.AracTeklif
                    join ai in _context.AracIhale on at.AracIhaleId equals ai.Id
					join uy in _context.Uye on at.UyeId equals uy.Id
                join ih in _context.Ihale on ai.IhaleId equals ih.Id
                join a in _context.Arac on ai.AracId equals a.Id
                where ai.AracId == aracId && ai.IsActive && ai.Id == at.AracIhaleId
                select new AracTeklif()
                {
                    AracIhaleId = ai.Id,
                    UyeId = ai.IhaleId,
					TeklifEdilenFiyat = at.TeklifEdilenFiyat,
					TeklifTarihi = at.TeklifTarihi,
					OnaylandiMi = at.OnaylandiMi,
					AracIhale = at.AracIhale
                }).ToListAsync();

            return ihale;
        }

        public async Task<Result> IhaledekiAracaTeklifVerme(AracTeklifDTO aracTeklif)
		{
			//var validator = new AracTeklifValidator(aracTeklif);
			//validator.OnValidate();

			//if (!validator.IsValid)
			//{
			//	string validationErrors = string.Join(Environment.NewLine, validator.ValidationMessages);
			//	return new ErrorResult(validationErrors);
			//}

			var yeniAracTeklif = new AracTeklif()
			{
				AracIhaleId = aracTeklif.AracIhaleId,
				TeklifEdilenFiyat = aracTeklif.TeklifEdilenFiyat,
				OnaylandiMi = false,
				UyeId = aracTeklif.UyeId,
				TeklifTarihi = DateTime.Now
			};

			_context.AracTeklif.Add(yeniAracTeklif);
			if (_context.SaveChanges() >0)
			{
				return new SuccessResult("Teklifiniz kaydedildi!");
			}
			return new ErrorResult("Teklif kaydedilemedi!");
		}
	}
}
