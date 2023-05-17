using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.AracDTOs.AracOzellikDTOs;
using IkinciElAracIhaleSistemiSonKullanici.AppCore.DTO.IhaleDTOs;

namespace IkinciElAracIhaleSistemiSonKullanici.UI.Models
{
	public class AracDetayViewModel
	{
		public IEnumerable<OzellikDetayDTO> IhaledekiAraclar { get; set; }
		public AracIhaleDTO AracinFiyatBilgisi { get; set; }
		public int AracId { get; set; }
	}
}
