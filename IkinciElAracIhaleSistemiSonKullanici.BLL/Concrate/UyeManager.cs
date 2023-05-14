using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.Enums;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.Results;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Context;
using IkinciElAracIhaleSistemiSonKullanici.DAL.UnitOfWork;
using UyeTurleri = IkinciElAracIhaleSistemi.Entities.VM.Enum.UyeTurleri;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Concrate
{
    public class UyeManager : IUyeManager
    {
        private readonly AracIhaleContext _context;
        public UyeManager(AracIhaleContext context)
        {
            _context = context;
        }
       
        public async Task<UyeSessionDTO> UyeKontrol(UyeGirisDTO uye)
        {
            var girisYapanUye = (from uy in _context.Uyeler 
                join ut in _context.UyeTurleri on  uy.UyeTuruId equals ut.UyeTuruId
                    join bu in _context.BireyselUyeler on uy.Id equals bu.UyeId
                    join ku in _context.KurumsalUyeler on uy.Id equals ku.UyeId
            where (uy.Email == uye.Mail && uy.Sifre == uye.Sifre)
                    select new UyeSessionDTO()
                    {
                        Isim = uy.Isim,
                        Soyisim = uy.Soyisim,
                        UyeTuru = uy.UyeTuru.UyeTuruAdi,
                        RolId = uy.UyeTuruId == (int)UyeTurleri.Bireysel ? (int)UyeRolleri.Bireysel : (int)UyeRolleri.Kurumsal,
                    }).SingleOrDefault();

            return girisYapanUye;
        }

    }
}
