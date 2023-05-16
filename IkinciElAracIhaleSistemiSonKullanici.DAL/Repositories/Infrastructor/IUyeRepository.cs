using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.UyeDTOs;
using IkinciElAracIhaleSistemiSonKullanici.Data;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor
{
	public interface IUyeRepository : ISelectableRepo<Uye>, ISelectableRepoAsync<Uye>
    {
	    public Task<UyeSessionDTO> UyeKontrol(UyeGirisDTO uye);
	    public int UyeRolunuGetir(int uyeTuruId);
    }
}
