using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.Data;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor
{
	public interface IIhaleRepository : ISelectableRepo<Ihale>, ISelectableRepoAsync<Ihale>
    {
	    public Task<List<Ihale>> TumIhaleleriGetir();
	    public Task<Ihale> IdyeGoreIhaleGetir(int id);
	    public Task<List<Ihale>> TumKurumsalIhaleleriGetir();
	    public Task<List<Ihale>> KurumsalFirmayaAitIhaleleriGetir(int id);
	    public Task<List<Ihale>> BireyselIhaleleriGetir();

    }
}
