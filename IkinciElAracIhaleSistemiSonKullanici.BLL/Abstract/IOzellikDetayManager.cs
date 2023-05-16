using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs.AracOzellikDTOs;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract
{
	public interface IOzellikDetayManager
	{
		public Task<List<OzellikDetayDTO>> AracOzellikleriniGetir(int id);
	}
}
