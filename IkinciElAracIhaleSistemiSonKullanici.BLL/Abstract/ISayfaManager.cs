using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract
{
	public interface ISayfaManager
	{
		public Task<List<UyeYetkiSayfaDTO>> RoleGoreSayfaYetkileriniGetir(int uyeRol);
	}
}
