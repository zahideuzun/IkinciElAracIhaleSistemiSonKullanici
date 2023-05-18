using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.Data;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor
{
	public interface ISayfaRepository : ISelectableRepo<Sayfa>, ISelectableRepoAsync<Sayfa>
	{
		public Task<List<Sayfa>> RoleGoreSayfaYetkileriniGetir(int uyeRol);
	}
}
