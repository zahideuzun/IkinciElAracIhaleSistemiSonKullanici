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

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Concrate
{
    public class IhaleManager : IIhaleManager
    {
        private readonly AracIhaleContext _context;
        public IhaleManager(AracIhaleContext context)
        {
            _context = context;
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
                    Statu = st.StatuAdi,
                    OlusturanKullanici = k.Kullanici.Isim,
                    OlusturulmaTarihi = (DateTime)k.CreatedDate
                }).ToList();

            return liste;
        }
    }
}
