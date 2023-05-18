using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.Data;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor
{
	public interface IAracIhaleRepository : ISelectableRepo<AracIhale>, ISelectableRepoAsync<AracIhale>
	{
		public Task<List<AracIhale?>> IhaleIdyeGoreIhaledekiAracFiyatBilgileriniGetir(int ihaleId);
		public Task<AracIhale?> AracIdyeGoreIhaledekiAracFiyatBilgisiniGetir(int aracId);
	}
}
