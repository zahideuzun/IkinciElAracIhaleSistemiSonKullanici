using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.Data;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor
{
	public interface IAracRepository : ISelectableRepo<Arac>, ISelectableRepoAsync<Arac>
	{
		public Task<List<Arac>> IhaledekiAraclariGetir(int id);
	}
}
