using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO;
using IkinciElAracIhaleSistemiSonKullanici.Data;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor
{
	public interface IUyeRepository : ISelectableRepo<Uye>, ISelectableRepoAsync<Uye>
    {
	    public Task<Uye> UyeKontrol(UyeGirisDTO uye);
	    public Task<int> UyeRolunuGetir(int uyeTuruId);

    }

   
}
