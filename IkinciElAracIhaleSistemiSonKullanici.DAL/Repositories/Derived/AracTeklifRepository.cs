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

		public Result IhaledekiAracaTeklifVerme(IhaleTeklifVermeDTO aracTeklif)
		{
			var validator = new AracTeklifValidator(aracTeklif);
			validator.OnValidate(); 

			if (!validator.IsValid)
			{
				string validationErrors = string.Join(Environment.NewLine, validator.ValidationMessages);
				return new ErrorResult(validationErrors); 
			}

			var yeniAracTeklif = new AracTeklif()
			{
				AracIhaleId = aracTeklif.AracIhaleId,
				TeklifEdilenFiyat = aracTeklif.TeklifEdilenFiyat,
				OnaylandiMi = false,
				UyeId = aracTeklif.UyeId,
				TeklifTarihi = DateTime.Now
			};

			_context.AracTeklif.Add(yeniAracTeklif);
			_context.SaveChanges();
			if (_context.SaveChanges() >0)
			{
				return new SuccessResult("Teklifiniz kaydedildi!");
			}
			return new ErrorResult("Teklif kaydedilemedi!");
		}
	}
}
