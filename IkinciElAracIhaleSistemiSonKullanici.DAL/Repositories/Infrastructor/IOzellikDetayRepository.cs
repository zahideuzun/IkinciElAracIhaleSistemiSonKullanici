using IkinciElAracIhaleSistemi.Entities.Entities;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor
{
	public interface IOzellikDetayRepository
	{
		public Task<List<OzellikDetay>> AracOzellikleriniGetir(int id);
	}
}
