using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.Enums;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Context;
using IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor;
using IkinciElAracIhaleSistemiSonKullanici.EF;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Derived
{
    public class UyeRepository : EfRepositoryBase<AracIhaleContext, Uye>, IUyeRepository
    {
	    private readonly AracIhaleContext _context;
		public UyeRepository()
        {
            
        }
        public UyeRepository(AracIhaleContext context) : base(context)
        {
			_context = context;
        }

		public async Task<UyeSessionDTO> UyeKontrol(UyeGirisDTO uye)
		{
			var girisYapanUye = (from uy in _context.Uye
				join ut in _context.UyeTuru on uy.UyeTuruId equals ut.UyeTuruId
				where (uy.Email == uye.Email && uy.Sifre == uye.Sifre)
				select new UyeSessionDTO()
				{
                    UyeId = uy.Id,
                    Isim = uy.Isim,
					Soyisim = uy.Soyisim,
					UyeTuruId = uy.UyeTuruId,
                    RolId = uy.UyeTuruId == (int)UyeTurleri.Bireysel ? (int)UyeRolleri.Bireysel : (int)UyeRolleri.Kurumsal
                }).SingleOrDefault();
            

			return girisYapanUye;
		}

		public int UyeRolunuGetir(int uyeTuruId)
		{
            if (uyeTuruId == (int)UyeTurleri.Bireysel)
            {
                var bireyselUye = (from bu in _context.BireyselUye
								  select new UyeRolDTO()
                                  {
									  UyeId = bu.UyeId,
									  RolId = bu.RolId
                                  }).SingleOrDefault();
                return bireyselUye.RolId;
            }
            if (uyeTuruId == (int)UyeTurleri.Kurumsal)
            {
                var kurumsalUye = (from bu in _context.KurumsalUye
                    select new UyeRolDTO()
                    {
                        UyeId = bu.UyeId,
                        RolId = bu.RolId
                    }).SingleOrDefault();
                return kurumsalUye.RolId;
            }

            return 0;
        }
	}
}
