using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract
{
	public interface IUyeManager
    {
        public Task<UyeSessionDTO> UyeKontrol(UyeGirisDTO uye);
		public int UyeRolunuGetir(int uyeRol);

	}
}
