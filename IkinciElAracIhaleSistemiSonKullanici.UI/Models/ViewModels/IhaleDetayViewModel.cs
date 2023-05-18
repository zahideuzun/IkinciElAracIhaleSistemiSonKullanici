using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;

namespace IkinciElAracIhaleSistemiSonKullanici.UI.Models.ViewModels
{
	public class IhaleDetayViewModel
	{
		public IhaleBilgisiDTO Ihale { get; set; }
		public List<AracIhaleDTO> AracFiyatBilgileri { get; set; }
		public List<AracBilgiDTO> IhaledekiAraclar { get; set; }
		public List<AracTeklifDTO>? AracTeklifleri { get; set; }
	}
}
