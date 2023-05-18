using IkinciElAracIhaleSistemi.Entities.Entities;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.Results.Bases;
using IkinciElAracIhaleSistemiSonKullanici.Data;

namespace IkinciElAracIhaleSistemiSonKullanici.DAL.Repositories.Infrastructor
{
	public interface IAracTeklifRepository : IInsertableRepo<AracTeklif>
	{
		public Task<Result> IhaledekiAracaTeklifVerme(AracTeklifDTO teklifDto);

        public Task<List<AracTeklif>> AracaVerilenTeklifleriGetir(int aracId);
    }
}
