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

		public async Task<Uye> UyeKontrol(UyeGirisDTO uye)
		{
			var girisYapanUye = (from uy in _context.Uye
				join ut in _context.UyeTuru on uy.UyeTuruId equals ut.UyeTuruId
				where (uy.Email == uye.Email && uy.Sifre == uye.Sifre)
				select new Uye()
				{
					Id=uy.Id,
					Isim = uy.Isim,
					Soyisim = uy.Soyisim,
					UyeTuruId = uy.UyeTuruId,
					Email = uy.Email,
					Sifre = uy.Sifre
				}).SingleOrDefault();
			return girisYapanUye;
		}

		public async Task<int> UyeRolunuGetir(int uyeTuruId)
		{
			var rolId = uyeTuruId == (int)UyeTurleri.Bireysel
				? (int)UyeRolleri.Bireysel
				: (int)UyeRolleri.Kurumsal;
			return rolId;
		}
	}
}
