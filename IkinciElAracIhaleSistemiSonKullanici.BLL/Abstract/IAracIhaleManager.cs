using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract
{
	public interface IAracIhaleManager
	{
		public Task<List<AracIhaleDTO>> IhaleIdyeGoreIhaledekiAracFiyatBilgileriniGetir(int ihaleId);
		public Task<AracIhaleDTO> AracIdyeGoreIhaledekiAracFiyatBilgisiniGetir(int aracId);
	}
}
