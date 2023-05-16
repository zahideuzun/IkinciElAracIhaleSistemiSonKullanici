using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract
{
	public interface IUyeManager
    {
        public Task<UyeGirisDTO> UyeKontrol(UyeGirisDTO uye);
		public Task<int> UyeRolunuGetir(int uyeTuruId);

	}
}
