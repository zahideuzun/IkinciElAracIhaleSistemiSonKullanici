using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract
{
	public interface IAracManager
	{
		public Task<List<AracBilgiDTO>> IhaledekiAraclariGetir(int id);
	}
}
