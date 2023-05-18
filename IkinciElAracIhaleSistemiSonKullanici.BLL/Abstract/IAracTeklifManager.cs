using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.Results.Bases;

namespace IkinciElAracIhaleSistemiSonKullanici.BLL.Abstract
{
    public interface IAracTeklifManager
	{
		public Task<Result> IhaledekiAracaYeniTeklifVerme(AracTeklifDTO teklifDto);
        public Task<List<AracTeklifDTO>> AracaVerilenTeklifleriGetir(int aracId);
    }
}
