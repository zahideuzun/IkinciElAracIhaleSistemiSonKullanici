using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;
using IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract;
using IkinciElAracIhaleSistemiSonKullanici.DAL.UnitOfWork;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL
{
    public class UyeManager : IUyeManager
    {
        private DataManager dataManager = new DataManager(); 
        public async Task<UyeSessionDTO> UyeKontrol(UyeGirisDTO uye)
        {
            var uyeRep = dataManager.GetUyeRepository();
            var dbdekiUye = uyeRep.GetBy(a => a.Email == uye.Mail && a.Sifre == uye.Sifre).SingleOrDefault();
            if (dbdekiUye != null)
            {
                return new UyeSessionDTO()
                {
                    Isim = dbdekiUye.Isim,
                    Soyisim = dbdekiUye.Soyisim,
                    UyeTuru = dbdekiUye.
                }
            }
        }
        
    }
}
