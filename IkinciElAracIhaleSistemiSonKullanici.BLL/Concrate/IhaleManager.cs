using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IkinciElAracIhaleSistemi.Entities.VM;
using IkinciElAracIhaleSistemi.Entities.VM.Enum;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Context;
using IkinciElAracIhaleSistemiSonKullanici.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Concrate
{
    public class IhaleManager : IIhaleManager
    {
        private readonly AracIhaleContext _context;
        public IhaleManager(AracIhaleContext context)
        {
            _context = context;
        }

        //todo ihale statu durumunu tarihe göre otomatik degistir

        public async Task<IhaleListesiDTO?> IdyeGoreIhaleGetir(int id)
        {
            var IdyeGoreIhale = (from ih in _context.Ihale
                join ist in _context.IhaleStatu on ih.Id equals ist.IhaleId
                where ih.Id == id
                select new IhaleListesiDTO()
                {
                    IhaleId = ih.Id,
                    IhaleAdi = ih.IhaleAdi,
                    IhaleTuru = ih.IhaleTuru.IhaleTuruAdi,
                    BaslangicTarihi = ih.IhaleBaslangicTarihi,
                    BaslangicSaati = ih.BaslangicSaat,
                    BitisSaati = ih.BitisSaat,
                    BitisTarihi = ih.IhaleBitisTarihi,
                    Statu = ist.Statu.StatuAdi
                }).SingleOrDefault();
            return IdyeGoreIhale;
        }

		public Task<IhaledekiAracBilgisiDTO?> IhaledekiAracBilgisiniGetir(int id)
		{
			return null;
		}

		public async Task<List<IhaleAraclariDTO>> IhaledekiAraclariGetir(int id)
        {
            int ihaleyeAitUyeId = (_context.Ihale.FirstOrDefault(a => a.Id == id).UyeId);
            if (ihaleyeAitUyeId != null)
            {
                var araclar = (from a in _context.Arac
                    join ast in _context.AracStatu on a.Id equals ast.AracId
                    join st in _context.Statu on ast.StatuId equals st.StatuId
                    where a.UyeId == ihaleyeAitUyeId && a.IsActive && ast.IsActive
                    select new IhaleAraclariDTO()
                    {
                        AracId = a.Id,
                        Plaka = a.Plaka,
                        Marka = a.Marka.MarkaAdi,
                        Model = a.Model.ModelAdi,
                        Km =a.Km
                    }).ToList();
                return araclar;
            }

            return null;
        }

        public async Task<List<IhaleListesiDTO>> TumIhaleleriGetir()
        {
            var liste = (from k in _context.Ihale
                join it in _context.IhaleTuru on k.IhaleTuruId equals it.IhaleTuruId
                join ist in _context.IhaleStatu on k.Id equals ist.IhaleId
                join st in _context.Statu on ist.StatuId equals st.StatuId
                where k.IsActive && ist.IsActive
                orderby k.CreatedDate descending
                select new IhaleListesiDTO()
                {
                    IhaleId = k.Id,
                    IhaleAdi = k.IhaleAdi,
                    IhaleTuru = k.IhaleTuruId == (int)IhaleTurleri.Bireysel ? "Bireysel" : "Kurumsal",
                    BaslangicTarihi = k.IhaleBaslangicTarihi,
                    BitisTarihi = k.IhaleBitisTarihi,
                    BaslangicSaati = k.BaslangicSaat,
                    BitisSaati = k.BitisSaat,
                    Statu = st.StatuAdi,
                    OlusturanKullanici = k.Kullanici.Isim,
                    OlusturulmaTarihi = (DateTime)k.CreatedDate
                }).ToList();

            return liste;
        }

       
    }
}
